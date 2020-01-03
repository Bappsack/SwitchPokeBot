using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SwitchPokeBot
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string comPort = string.Empty;
        public bool Use_Countdown { get; set; }
        private SwitchPokeBot.Bot.Suprise_Bot suprise = new Bot.Suprise_Bot();
        private SwitchPokeBot.Bot.Link_Bot link = new Bot.Link_Bot();

        public Form1()
        {
            InitializeComponent();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            RefreshCOMPorts();
        }

        public void ApplyLog(string Text)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<string>(ApplyLog), new object[] { Text });
                    return;
                }

                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Logs\"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Logs\");
                }
                string Filename = DateTime.Now.ToShortDateString().Replace(@"\", ".").Replace(@"/", ".") + ".txt";
                File.AppendAllText(Directory.GetCurrentDirectory() + @"\Logs\" + Filename, "[" + DateTime.Now.ToString("HH:mm:ss") + "]: " + Text + "\n");

                this.LogBox.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "]: " + Text + "\n");
                this.LogBox.ScrollToCaret();
            }
            catch { }
        }

        public void UpdateStatus(string Text)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<string>(UpdateStatus), new object[] { Text });
                    return;
                }
                metroLabel8.Text = $"Status: {Text}";
            }
            catch { }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Use_Countdown = showPokemon.Checked;
            comPort = comPort_select.Text;
            if (comPort != string.Empty && comPort_select.Items.Contains(comPort) && comPort.ToUpper().Contains("COM"))
            {
                if (!Program.botRunning)
                {

                    Program.botRunning = true;
                    suprise.RunBot(comPort, Convert.ToInt32(Slot_SupriseTrade.Text), Convert.ToInt32(reconnectAfter_combo.Text), UseSync.Checked, showPokemon.Checked);
                    ApplyLog($"Suprise Trade Bot Started!");
                }
                else
                {
                    MessageBox.Show("Bot is already running!");
                    return;
                }

            }
            else
            {
                MessageBox.Show("No Port Selected!");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (Program.botRunning)
            {
                Program.botRunning = false;
            }
            else
            {
                MessageBox.Show("Bot isn't running!");
                return;
            }
        }

        private void RefreshCOMPorts()
        {
            comPort_select.Items.Clear();
            foreach (var serialPort in SerialPort.GetPortNames())
            {
                comPort_select.Items.Add(serialPort);
                comPort_select.Text = serialPort;
            }
            ApplyLog($"Found {SerialPort.GetPortNames().Length} Com Ports!");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUSBDisplay(false);
            RefreshCOMPorts();

            for (int i = 1; i < 31; i++)
            {
                Slot_SupriseTrade.Items.Add(i);
            }
            Slot_SupriseTrade.Text = "0";


            for (int i = 1; i < 31; i++)
            {
                slot_Link.Items.Add(i);
            }
            slot_Link.Text = "0";


            for (int i = 1; i < 961; i++)
            {
                reconnectAfter_combo.Items.Add(i);
            }


            UseSync.Checked = Properties.Settings.Default.ShowPokemon;
            showPokemon.Checked = Properties.Settings.Default.UseSync;
            Slot_SupriseTrade.Text = Properties.Settings.Default.StartSlotSuprise;
            slot_Link.Text = Properties.Settings.Default.StartSlotLink;
            reconnectAfter_combo.Text = Properties.Settings.Default.ReconnectAfter;
            LinkCodeBox.Text = Properties.Settings.Default.LinkCode;
            Slot_SupriseTrade.Text = Properties.Settings.Default.COMPort;
            comPort_select.Text = Properties.Settings.Default.COMPort;
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            ApplyLog("Saving...");
            Properties.Settings.Default.UseSync = showPokemon.Checked;
            Properties.Settings.Default.ShowPokemon = UseSync.Checked;
            Properties.Settings.Default.ReconnectAfter = reconnectAfter_combo.Text;
            Properties.Settings.Default.StartSlotSuprise = Slot_SupriseTrade.Text;
            Properties.Settings.Default.LinkCode = LinkCodeBox.Text;
            Properties.Settings.Default.COMPort = comPort_select.Text;
            Properties.Settings.Default.StartSlotLink = slot_Link.Text;
            Properties.Settings.Default.Save();

            Program.botRunning = false;
        }

        public void UpdateUSBDisplay(bool Status)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<bool>(UpdateUSBDisplay), new object[] { Status });
                    return;
                }
                if (Status)
                {
                    pictureBox1.Image = Properties.Resources.usb_connected_xxl;
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    UpdateStatus("Connected!");
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.usb_disconnected_xxl;
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    UpdateStatus("Disconnected!");
                }

            }
            catch { }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            LogBox.Clear();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            comPort = comPort_select.Text;
            if (comPort != string.Empty && comPort_select.Items.Contains(comPort) && comPort.ToUpper().Contains("COM"))
            {
                if (!Program.botRunning)
                {
                    if (LinkCodeBox.Text.Length < 4 || LinkCodeBox.Text != "0000")
                    {
                        Program.botRunning = true;
                        link.RunBot(comPort, Convert.ToInt32(slot_Link.Text), Convert.ToInt32(reconnectAfter_combo.Text), UseSync.Checked, LinkCodeBox.Text);
                        ApplyLog($"Link Trade Code Bot Started!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Link Code Selected!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Bot is already running!");
                    return;
                }

            }
            else
            {
                MessageBox.Show("No Port Selected!");
            }
        }
    }
}
