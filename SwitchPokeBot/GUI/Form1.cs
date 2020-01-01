using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SwitchPokeBot
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string comPort = string.Empty;
        public bool Use_YT_Countdown { get; set; }
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

                this.richTextBox1.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "]: " + Text + "\n");
                this.richTextBox1.ScrollToCaret();
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
            Use_YT_Countdown = metroCheckBox2.Checked;
            comPort = metroComboBox3.Text;
            if (comPort != string.Empty && metroComboBox3.Items.Contains(comPort) && comPort.ToUpper().Contains("COM"))
            {
                if (!Program.botRunning)
                {

                    Program.botRunning = true;
                    suprise.RunBot(comPort, Convert.ToInt32(metroComboBox1.Text), Convert.ToInt32(metroComboBox1.Text), metroCheckBox1.Checked, metroCheckBox1.Checked);
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
            metroComboBox3.Items.Clear();
            foreach (var serialPort in SerialPort.GetPortNames())
            {
                metroComboBox3.Items.Add(serialPort);
                metroComboBox3.Text = serialPort;
            }
            ApplyLog($"Found {SerialPort.GetPortNames().Length} Com Ports!");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUSBDisplay(false);
            RefreshCOMPorts();

            for (int i = 1; i < 31; i++)
            {
                metroComboBox1.Items.Add(i);
            }
            metroComboBox1.Text = "0";


            for (int i = 1; i < 961; i++)
            {
                metroComboBox2.Items.Add(i);
            }


            metroCheckBox1.Checked = Properties.Settings.Default.ShowPokemon;
            metroCheckBox2.Checked = Properties.Settings.Default.UseSync;
            metroComboBox1.Text = Properties.Settings.Default.StartSlot;
            metroComboBox2.Text = Properties.Settings.Default.ReconnectAfter;
            metroTextBox1.Text = Properties.Settings.Default.LinkCode;
            metroComboBox1.Text = Properties.Settings.Default.COMPort;
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            ApplyLog("Saving...");
            Properties.Settings.Default.UseSync = metroCheckBox2.Checked;
            Properties.Settings.Default.ShowPokemon = metroCheckBox1.Checked;
            Properties.Settings.Default.ReconnectAfter = metroComboBox2.Text;
            Properties.Settings.Default.StartSlot = metroComboBox1.Text;
            Properties.Settings.Default.LinkCode = metroTextBox1.Text;
            Properties.Settings.Default.COMPort = metroComboBox1.Text;
            Properties.Settings.Default.Save();

            Program.botRunning = false;
            Environment.Exit(0);
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
            richTextBox1.Clear();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Use_YT_Countdown = metroCheckBox2.Checked;
            comPort = metroComboBox3.Text;
            if (comPort != string.Empty && metroComboBox3.Items.Contains(comPort) && comPort.ToUpper().Contains("COM"))
            {
                if (!Program.botRunning)
                {
                    if (metroTextBox1.Text.Length < 4 || metroTextBox1.Text != "0000")
                    {
                        Program.botRunning = true;
                        link.RunBot(comPort, Convert.ToInt32(metroComboBox1.Text), Convert.ToInt32(metroComboBox1.Text), metroCheckBox1.Checked, metroTextBox1.Text);
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
