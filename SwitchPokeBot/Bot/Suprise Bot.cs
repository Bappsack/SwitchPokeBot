using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchPokeBot.Bot
{
    class Suprise_Bot
    {
        private int botResult { get; set; }
        private int Box { get; set; }
        private int CurrentTrades { get; set; }

        private string Port { get; set; }
        private int Slot { get; set; }
        private int ReconnectAfter { get; set; }
        private bool UseSync { get; set; }
        private bool ShowPokemon { get; set; }


        private SwitchInputSink Input;

        public void RunBot(string port, int slot, int reconnectAfter, bool useSync, bool showPokemon)
        {
            Port = port;
            Slot = slot;
            if(Slot > 0) { Slot--; }
            ReconnectAfter = reconnectAfter;
            UseSync = useSync;
            ShowPokemon = showPokemon;

            var worker = new Thread(Bot);
            worker.Start();
        }


        public void Bot()
        {
            // Start Horipad Emulator(InputRedirection)

            string RegistyKey = "HKEY_CURRENT_USER\\SOFTWARE\\Mitsuki\\WTBots";
            string RegistyBotReadyCount = "BotsReadyCount";
            string RegistyBotCount = "BotsAmount";
            int Bots = 0;
            int BotsAmount = 0;

            Input = new SwitchInputSink(Port);
            Input.BotWait(3000);
            if(UseSync)
            {
                Program.form.ApplyLog("Bot Sync is Enabled!");
            }
            Program.form.ApplyLog("Starting Bot in 5 Seconds...");
            Input.SendButton(Button.B, 1000);
            Input.SendButton(Button.B, 1000);
            Input.SendButton(Button.B, 1000);
            
            while (Program.botRunning)
            {
                try
                {

                  
                    if (CurrentTrades >= ReconnectAfter)
                    {
                        //Reconnect if disconnected
                        Program.form.ApplyLog("Auto Reconnect is enabled, reconnecting if disconnected...");
                        // Open Y-COM
                        Program.form.ApplyLog("Open Y-COM Menu");
                        Input.SendButton(Button.Y, 2000);

                        //Press Plus, don't need a confirmation if not connected
                        Input.SendButton(Button.Plus, 2000);
                        Program.form.ApplyLog("Wait 15 Seconds to ensure we are connected");
                        //Wait 15 Seconds
                        Input.BotWait(15000);
                        Program.form.ApplyLog("Reconnected! Return to Overworld");
                        //Return to Overworld
                        Input.SendButton(Button.B, 1500);
                        Input.SendButton(Button.B, 1500);
                        CurrentTrades = 0;
                    }


                    Program.form.ApplyLog("Open Y-COM Menu");
                    Input.SendButton(Button.Y, 2000);
                    Program.form.ApplyLog("Select Suprise Trade");
                    Input.SendDpad(DPad.Down, 100);
                    Input.SendButton(Button.A, 1000);
                    Input.BotWait(3000);

                    Program.form.ApplyLog("Select Pokemon");
                    SelectBoxSlot(Box, Slot, 250);

                    Input.SendButton(Button.A, 2000);
                    
                    if (ShowPokemon)
                    {
                        Program.form.ApplyLog("Show Pokemon is enabled, wait 15 Seconds...");
                        Input.BotWait(new Random().Next(13000, 15000));
                    }
                    //Start a Suprise Trade, in case of Empty Slot/Egg/Bad Pokemon we press sometimes B to return to the Overworld and skip this Slot.
                    Program.form.ApplyLog("Confirming...");
                    Input.SendButton(Button.A, 1000);
                    Input.SendButton(Button.A, 3000);

                    if (UseSync) 
                    {
                        Bots = Convert.ToInt16(Registry.GetValue(RegistyKey, RegistyBotReadyCount, 0).ToString());
                        BotsAmount = Convert.ToInt16(Registry.GetValue(RegistyKey, RegistyBotCount, 0).ToString());
                        // Increase BotReady Count
                        Program.form.ApplyLog("Waiting for other Bots...");
                        Bots++;
                        Registry.SetValue(RegistyKey, RegistyBotReadyCount, Bots.ToString(), RegistryValueKind.String);
                       

                        while (Bots < BotsAmount)
                        {
                            // Get Registry Values for Bots
                            Bots = Convert.ToInt16(Registry.GetValue(RegistyKey, RegistyBotReadyCount, 0).ToString());
                            BotsAmount = Convert.ToInt16(Registry.GetValue(RegistyKey, RegistyBotCount, 0).ToString());
                            
                            Program.form.UpdateStatus("Waiting for other Bots...");
                            Input.BotWait(new Random().Next(50,150));
                        }
                        Program.form.ApplyLog("Bots are Ready!");
                    }
                    Input.SendButton(Button.A, 1000);
                    Input.SendButton(Button.A, 2000);
                    Input.SendButton(Button.A, 3000);
                    Program.form.ApplyLog("Suprise Trade Started, wait 10 seconds...");
                    Input.SendButton(Button.B, 1000);
                    Input.SendButton(Button.B, 1000);
                    Input.SendButton(Button.B, 1000);
                    Input.SendButton(Button.B, 1000);

                    Input.SendButton(Button.A, 1500);
                    Input.SendButton(Button.A, 1500);
                    Program.form.ApplyLog("Wait until Trade is finished, prevent auto disconnect by walking arround");

                    for (int BypassDisconnect = 0; BypassDisconnect < 40; BypassDisconnect++)
                    {
                        Input.SendAnalog(0, 128, 128, 128, 100); // Left
                        Input.SendAnalog(-20, 128, 128, 128, 100); // Right
                    }

                    Program.form.ApplyLog("Pokemon has been arrived, confirm.");
                    Input.SendButton(Button.Y, 1000);

                    Input.SendButton(Button.B, 1000);
                    Input.SendButton(Button.B, 1000);
                    Input.SendButton(Button.B, 1000);

                    // Spam A Button for 40 seconds in Case of Trade Evolution/Moves Learnings/Dex
                    for (int ii = 0; ii < 40; ii++)
                    {
                        Input.SendButton(Button.A, 1000);
                    }

                    Input.SendButton(Button.B, 1000);
                    Input.SendButton(Button.B, 1000);
                    Input.SendButton(Button.B, 1000);
                    Program.form.ApplyLog("Trade was Successfull!");

                    if (Slot >= 29)
                    {
                        Box++;
                        Slot = 0;
                    }
                    else
                    {
                        Slot++;
                    }
                    CurrentTrades++;
                }
                catch
                {
                    Program.form.ApplyLog("Bot lost connection to Host, check your cable connected!");
                    Program.form.UpdateStatus("Disconnected! | Can't connect to Host!");
                }
            }


        }


        private void SelectBoxSlot(int Box, int Slot, int Delay)
        {
            if (Program.botRunning)
            {
                int Right = 0;
                int Down = 0;
                bool BoxChange = false;
                Program.form.ApplyLog("Box: " + (Box +1) + ", Slot: " + (Slot +1));

                if (Slot >= 30)
                {
                    BoxChange = true;
                }

                // Bos Switch
                if (BoxChange)
                {
                    Program.form.ApplyLog("Changing Box...");
                    Input.SendDpad(DPad.Up, 250);
                    Input.SendDpad(DPad.Right, 250);
                    Input.SendDpad(DPad.Down, 250);
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
                    Input.SendDpad(DPad.Down, 300);
                }

                for (int RightDirection = 0; RightDirection < Right; RightDirection++)
                {
                    Input.SendDpad(DPad.Right, 300);
                }
                Input.BotWait(Delay);
            }
        }
    }


}
