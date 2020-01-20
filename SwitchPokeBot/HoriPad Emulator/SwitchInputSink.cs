using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Threading;

namespace SwitchPokeBot
{
    class SwitchInputState
    {
        public Button Buttons { get; set; }
        public DPad DPad { get; set; }
        public byte LeftX { get; set; }
        public byte LeftY { get; set; }
        public byte RightX { get; set; }
        public byte RightY { get; set; }

        public bool Equals(SwitchInputState other)
        {
            return Buttons == other.Buttons &&
                   DPad == other.DPad &&
                   LeftX == other.LeftX &&
                   LeftY == other.LeftY &&
                   RightX == other.RightX &&
                   RightY == other.RightY;
        }
    }

    public class SwitchInputSink : IInputSink
    {

        private SwitchInputState _state;
        private SerialPort _serialPort;
        private ConcurrentQueue<InputFrame> _queuedFrames;
        private OnUpdateCallback _callback;
        private readonly object _lock = new object();
        public InputFrame newFrame = new InputFrame();
        public SwitchInputSink(string portName)
        {
            _state = new SwitchInputState();
            _queuedFrames = new ConcurrentQueue<InputFrame>();
            var workerThread = new Thread(ThreadLoop);
            workerThread.Start(portName);
            Update(new InputFrame
            {
                PressedButtons = Button.None,
                ReleasedButtons = Button.All,
                DPad = DPad.None,
                LeftX = 128,
                LeftY = 128,
                RightX = 128,
                RightY = 128
            });
        }

        ~SwitchInputSink()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }

            _serialPort = null;
        }

        private void ThreadLoop(object arg)
        {
            Program.botRunning = true;
            int CurrentTrades = 0;
            Program.form.ApplyLog("Trying to connect to Console...");
            Program.form.UpdateStatus("Connecting...");
            var portName = (string)arg;
            _serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = 19200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                ReadTimeout = 100,
                WriteTimeout = 100
            };
            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                Program.form.ApplyLog("Can't open Port: " + portName);
            }
            if (!Sync())
            {
                Program.form.ApplyLog("Can't connect to Console, Bot Stopped!");
                Program.form.UpdateStatus("Disconnected! | Can't connect to Console!");
                // throw new Exception("Unable to sync");
                Program.botRunning = false;
                Program.botConnected = false;
                return;
            }
            Program.botConnected = true;
            Program.form.UpdateStatus("Connected!");
            Program.form.UpdateUSBDisplay(true);
            Program.form.ApplyLog("Connected to Console successfully!");

            var serv = new Thread(KeepAlive);
            serv.Start();
        }

        public void Stop()
        {
            try
            {
                Program.botRunning = false;
                Program.botConnected = false;
                _serialPort.Close();
            }
            catch { }
        }

        public void KeepAlive()
        {
            while (Program.botRunning)
            {
                if (newFrame.Wait <= 0)
                {
                    if (_queuedFrames.TryDequeue(out var queuedFrame))
                    {
                        newFrame = queuedFrame;
                        ApplyFrameToState(newFrame);
                        _callback?.Invoke(GetStateStr());
                        var packet = TranslateState(_state);
                        _serialPort.Write(packet, 0, packet.Length);
                    }
                }
                else
                {
                    newFrame.Wait--;
                    Reset();
                }
                try
                {
                    var resp = _serialPort.ReadByte();
                    if (resp == 0x92)
                    {
                        Console.Error.WriteLine("NACK");
                        if (!Sync())
                        {
                            throw new Exception("Unable to sync after NACK");
                        }
                    }
                    else if (resp != 0x90)
                    {
                        // Unknown response
                    }
                }
                catch
                {
                    Program.form.ApplyLog("Connection lost!");
                    Program.botConnected = false;
                    Program.botRunning = false;
                }
                Thread.Sleep(10);
            }

            _serialPort.Dispose();
            _serialPort.Close();
            Program.form.UpdateStatus("Disconnected!");
            Program.form.UpdateUSBDisplay(false);
        }


        public void SendButton(Button button, int Delay)
        {
            try
            {
                newFrame = new InputFrame();
                newFrame.PressedButtons = button;
                // newFrame.Wait = 1;
                Update(newFrame);
                BotWait(150);
                newFrame.PressedButtons = Button.None;
                newFrame.ReleasedButtons = Button.All;
                Update(newFrame);
                BotWait(Delay);
            }
            catch (Exception ex)
            {
                Program.form.ApplyLog(ex.Message);
            }
        }

        public void SendDpad(DPad button, int Delay)
        {
            try
            {
                if (Program.botRunning || _serialPort.IsOpen)
                {
                    newFrame = new InputFrame();
                    newFrame.DPad = button;
                    //newFrame.Wait = 1;
                    Update(newFrame);
                    BotWait(150);
                    newFrame.DPad = DPad.None;
                    Update(newFrame);
                    BotWait(Delay);
                }
            }
            catch (Exception ex)
            {
                Program.form.ApplyLog(ex.Message);
            }
        }

        public void SendAnalog(Int32 LX, Int32 LY, Int32 RX, Int32 RY, int Delay)
        {
            try
            {
                if (Program.botRunning || _serialPort.IsOpen)
                {
                    newFrame = new InputFrame();
                    newFrame.LeftX = (byte)LX;
                    newFrame.LeftY = (byte)LY;
                    newFrame.RightX = (byte)RX;
                    newFrame.RightY = (byte)RY;
                    Update(newFrame);
                    BotWait(new Random().Next(800, 1000));
                    newFrame.LeftX = 128;
                    newFrame.LeftY = 128;
                    newFrame.RightX = 128;
                    newFrame.RightY = 128;
                    Update(newFrame);
                    BotWait(Delay);
                }
            }
            catch (Exception ex)
            {
                Program.form.ApplyLog(ex.Message);
            }
        }



        public void Reset()
        {
            try
            {
                var newFrame2 = new InputFrame
                {
                    PressedButtons = Button.None,
                    ReleasedButtons = Button.All,
                    DPad = DPad.None,
                    LeftX = 128,
                    LeftY = 128,
                    RightX = 128,
                    RightY = 128,
                };
                _queuedFrames = new ConcurrentQueue<InputFrame>();
                Update(newFrame2);
            }
            catch (Exception ex)
            {
                Program.form.ApplyLog(ex.Message);
            }
        }

        public void Update(InputFrame newFrame)
        {
            _queuedFrames.Enqueue(newFrame);
        }

        public void WaitFrames(int numFrames)
        {
            if (numFrames <= 0) return;
            Update(new InputFrame
            {
                Wait = numFrames - 1
            });
        }

        public void BotWait(int Delay)
        {
            try
            {
                if (Program.botRunning)
                {
                    Thread.Sleep(Delay);
                }
            }
            catch (Exception ex)
            {
                Program.form.ApplyLog(ex.Message);
            }
        }

        public string GetStateStr()
        {
            return
                $"{(int)_state.Buttons} {(int)_state.DPad} {_state.LeftX} {_state.LeftY} {_state.RightX} {_state.RightY}";
        }

        public void AddStateListener(OnUpdateCallback cb)
        {
            _callback = cb;
        }

        private bool Sync()
        {
            try
            {
                var sendBytes = new byte[] { 0xff, 0x33, 0xcc };
                var recvBytes = new byte[] { 0xff, 0xcc, 0x33 };

                for (var i = 0; i < 100; i++)
                {
                    var synced = false;
                    _serialPort.DiscardOutBuffer();
                    _serialPort.DiscardInBuffer();

                    _serialPort.Write(sendBytes, 0, 1);
                    Thread.Sleep(100);
                    while (_serialPort.BytesToRead > 0)
                    {
                        var b = _serialPort.ReadByte();
                        if (b == recvBytes[0])
                        {
                            synced = true;
                            break;
                        }
                    }
                    _serialPort.DiscardInBuffer();

                    if (!synced) continue;
                    synced = false;

                    _serialPort.Write(sendBytes, 1, 1);
                    Thread.Sleep(100);
                    while (_serialPort.BytesToRead > 0)
                    {
                        var b = _serialPort.ReadByte();
                        if (b == recvBytes[1])
                        {
                            synced = true;
                            break;
                        }
                    }

                    if (!synced) continue;
                    synced = false;

                    _serialPort.Write(sendBytes, 2, 1);
                    Thread.Sleep(100);
                    while (_serialPort.BytesToRead > 0)
                    {
                        var b = _serialPort.ReadByte();
                        if (b == recvBytes[2])
                        {
                            synced = true;
                            break;
                        }
                    }

                    if (synced) return true;
                }
            }
            catch { }

            return false;
        }

        private void ApplyFrameToState(InputFrame frame)
        {
            try
            {
                _state = new SwitchInputState
                {
                    Buttons = (_state.Buttons | (frame.PressedButtons ?? Button.None)) & ~(frame.ReleasedButtons ?? Button.None), // & ~(Button.Home | Button.Share),
                    DPad = frame.DPad ?? _state.DPad,
                    LeftX = frame.LeftX ?? _state.LeftX,
                    LeftY = frame.LeftY ?? _state.LeftY,
                    RightX = frame.RightX ?? _state.RightX,
                    RightY = frame.RightY ?? _state.RightY
                };
            }
            catch (Exception ex)
            {
                Program.form.ApplyLog(ex.Message);
            }
        }

        private byte[] TranslateState(SwitchInputState state)
        {
            var buf = new byte[9];
            buf[0] = (byte)(((int)state.Buttons & 0xFF00) >> 8);
            buf[1] = (byte)((int)state.Buttons & 0xFF);
            buf[2] = (byte)state.DPad;
            buf[3] = state.LeftX;
            buf[4] = state.LeftY;
            buf[5] = state.RightX;
            buf[6] = state.RightY;
            buf[7] = 0;
            buf[8] = Utils.CalculateCrc8(buf, 0, buf.Length - 1);
            return buf;
        }
    }
}
