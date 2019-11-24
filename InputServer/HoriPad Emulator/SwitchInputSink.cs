using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace InputServer
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
        public int Slot { get; set; }
        public int Box { get; set; }
        public int ReconnectTrades { get; set; }
        public bool UseTimer { get; set; }

        private SwitchInputState _state;
        private SerialPort _serialPort;
        private ConcurrentQueue<InputFrame> _queuedFrames;
        private OnUpdateCallback _callback;
        private readonly object _lock = new object();
        public InputFrame newFrame = new InputFrame();
        public SwitchInputSink(string portName, int slot, int reconnectTrades, bool useTimer)
        {
            _state = new SwitchInputState();
            _queuedFrames = new ConcurrentQueue<InputFrame>();
            Slot = slot;
            ReconnectTrades = reconnectTrades;
            UseTimer = useTimer;
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
            Program.form.ApplyLog("Trying to Sync...");
            var portName = (string) arg;
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
            catch { }
            Program.form.UpdateStatus("Connected!");
            if (!Sync())
            {
                Program.form.ApplyLog("Can't Sync with Console, Bot Stopped!");
                Program.form.UpdateStatus("Disconnected! | Can't connect to Host!");
                // throw new Exception("Unable to sync");
                return;
            }
            Program.form.ApplyLog("Synced");

            var serv = new Thread(KeepAlive);
            serv.Start();
            Thread.Sleep(100);
            Program.form.ApplyLog("Starting Bot in 5 Seconds...");
            SendButton(Button.B, 1000);
            SendButton(Button.B, 1000);
            SendButton(Button.B, 1000);
            Thread.Sleep(1000);
            while(false)//while (Program.botRunning)
            {
                try
                {
                    if (CurrentTrades >= ReconnectTrades)
                    {
                        //Reconnect if disconnected
                        Program.form.ApplyLog("Check if still connected");
                        // Open Y-COM
                        Program.form.ApplyLog("Open Y-COM Menu");
                        SendButton(Button.Y, 2000);

                        //Press Plus, don't need a confirmation if not connected
                        SendButton(Button.Plus, 2000);
                        Program.form.ApplyLog("Wait 15 Seconds to ensure we are connected");
                        //Wait 15 Seconds
                        BotWait(15000);
                        Program.form.ApplyLog("Return to Overworld");
                        //Return to Overworld
                        SendButton(Button.B, 1200);
                        SendButton(Button.B, 1200);
                        CurrentTrades = 0;
                    }

                    Program.form.ApplyLog("Open Y-COM Menu");
                    SendButton(Button.Y, 2000);
                    Program.form.ApplyLog("Select Suprise Trade");
                    SendDpad(DPad.Down, 100);
                    SendButton(Button.A, 1000);
                    BotWait(3000);

                    Program.form.ApplyLog("Select Pokemon");
                    SelectBoxSlot(Box, Slot, 250);

                    SendButton(Button.A, 2000);

                    //Start a Suprise Trade, in case of Empty Slot/Egg/Bad Pokemon we press sometimes B to return to the Overworld and skip this Slot.
                    Program.form.ApplyLog("Confirming...");
                    SendButton(Button.A, 1000);
                    SendButton(Button.A, 3000);
                    SendButton(Button.A, 1000);
                    SendButton(Button.A, 2000);
                    SendButton(Button.A, 3000);
                    SendButton(Button.B, 1000);
                    SendButton(Button.B, 1000);
                    SendButton(Button.B, 1000);
                    SendButton(Button.B, 1000);

                    SendButton(Button.A, 1500);
                    SendButton(Button.A, 1500);
                    Program.form.ApplyLog("Suprise Trade started, walking around for 60 Seconds");

                    for (int ui = 0; ui < 15; ui++)
                    {
                        SendAnalog(0, 128, 128, 128, 100); // Left
                        SendAnalog(-20, 128, 128, 128, 100); // Right
                    }

                    Program.form.ApplyLog("Trade Finished, confirm.");
                    SendButton(Button.Y, 1000);

                    SendButton(Button.B, 1000);
                    SendButton(Button.B, 1000);
                    SendButton(Button.B, 1000);

                    // Spam A Button for 30 seconds in Case of Trade Evolution/Moves Learnings/Dex (might to be increased, needs testing)
                    for (int ii = 0; ii < 40; ii++)
                    {
                        SendButton(Button.A, 1000);
                    }

                    SendButton(Button.B, 1000);
                    SendButton(Button.B, 1000);
                    SendButton(Button.B, 1000);

                    Program.form.ApplyLog("Start from beginning");

                    if (Slot > 29)
                    {
                        Program.form.ApplyLog("Change Box, Reset Slot!");
                        Box++;
                        Slot = 0;
                    }
                    else
                    {
                        Slot++;
                    }
                }
                catch
                {
                    Program.form.ApplyLog("Bot lost connection to Host, check your cable connected!");
                    Program.form.UpdateStatus("Disconnected! | Can't connect to Host!");
                }
            }
           // _serialPort.Dispose();
           // _serialPort.Close();
            Program.form.UpdateStatus("Disconnected!");
        }

        public void Stop()
        {
            _serialPort.Close();
        }

        public void KeepAlive()
        {
            while(Program.botRunning)
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
                Thread.Sleep(100);
            }

            _serialPort.Dispose();
            _serialPort.Close();
            Program.form.UpdateStatus("Disconnected!");
        }


        public void SendButton(Button button,int Delay)
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

        public void SendDpad(DPad button, int Delay)
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

        public void SendAnalog(Int32 LX, Int32 LY, Int32 RX, Int32 RY, int Delay)
        {
            if (Program.botRunning || _serialPort.IsOpen)
            {
                newFrame = new InputFrame();
                newFrame.LeftX = (byte)LX;
                newFrame.LeftY = (byte)LY;
                newFrame.RightX = (byte)RX;
                newFrame.RightY = (byte)RY;
                Update(newFrame);
                BotWait(1500);
                newFrame.LeftX = 128;
                newFrame.LeftY = 128;
                newFrame.RightX = 128;
                newFrame.RightY = 128;
                Update(newFrame);
                BotWait(Delay);
            }
        }

        public void SelectBoxSlot(int Box, int Slot, int Delay)
        {
            if (Program.botRunning || _serialPort.IsOpen)
            {
                int Right = 0;
                int Down = 0;
                bool BoxChange = false;
                Program.form.ApplyLog("Box: " + Box + ", Slot: " + Slot);

                if (Slot >= 30)
                {
                    BoxChange = true;
                }

                // Bos Switch
                if (BoxChange)
                {
                    Program.form.ApplyLog("ChangeBox...");
                    SendDpad(DPad.Up, 250);
                    SendDpad(DPad.Right, 250);
                    SendDpad(DPad.Down, 250);
                    Slot = 0;
                }

                // Select wanted Slot, Down Side
                if (Slot > 5 && Slot < 12)
                {
                    Down = 1;
                }
                else if (Slot > 11 && Slot < 18)
                {
                    Down = 2;
                }
                else if (Slot > 17 && Slot < 24)
                {
                    Down = 3;
                }
                else if (Slot > 23 && Slot < 30)
                {
                    Down = 4;
                }

                // Select wanted Slot, Right Side

                Right = Slot;

                if (Slot > 5 && Slot < 12)
                {
                    Right -= 6;
                }

                if (Slot > 11 && Slot < 18)
                {
                    Right -= 12;
                }

                if (Slot > 17 && Slot < 24)
                {
                    Right -= 18;
                }

                if (Slot > 23 && Slot < 30)
                {
                    Right -= 24;
                }

                for (int DownDirection = 0; DownDirection < Down; DownDirection++)
                {
                    SendDpad(DPad.Down, 300);
                }

                for (int RightDirection = 0; RightDirection < Right; RightDirection++)
                {
                    SendDpad(DPad.Right, 300);
                }
                BotWait(Delay);
            }
        }


        public void Reset()
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
            if(Program.botRunning)
            {
                Thread.Sleep(Delay);
            }
        }
            
        public string GetStateStr()
        {
            return
                $"{(int) _state.Buttons} {(int) _state.DPad} {_state.LeftX} {_state.LeftY} {_state.RightX} {_state.RightY}";
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

        private byte[] TranslateState(SwitchInputState state)
        {
            var buf = new byte[9];
            buf[0] = (byte) (((int) state.Buttons & 0xFF00) >> 8);
            buf[1] = (byte) ((int) state.Buttons & 0xFF);
            buf[2] = (byte) state.DPad;
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
