using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SwitchPokeBot
{
    public partial class Form1 : Form
    {
        private string comPort = string.Empty;
        public bool Use_YT_Countdown { get; set; }
        private SwitchPokeBot.Bot.Suprise_Bot suprise = new Bot.Suprise_Bot();

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
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
                label1.Text = $"Status: {Text}";
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Use_YT_Countdown = checkBox2.Checked;
            comPort = comboBox1.Text;
            if (comPort != string.Empty && comboBox1.Items.Contains(comPort) && comPort.ToUpper().Contains("COM"))
            {
                if (!Program.botRunning)
                {

                    Program.botRunning = true;
                    suprise.RunBot(comPort, Convert.ToInt32(comboBox2.Text), Convert.ToInt32(comboBox3.Text), checkBox2.Checked, checkBox1.Checked);
                    ApplyLog($"Bot Started!");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.botRunning)
            {
                Program.botRunning = false;
                ApplyLog($"Bot Stopped!");
            }
            else
            {
                MessageBox.Show("Bot isn't running!");
                return;
            }
        }

        private void RefreshCOMPorts()
        {
            comboBox1.Items.Clear();
            foreach (var serialPort in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(serialPort);
                comboBox1.Text = serialPort;
            }
            ApplyLog($"Found {SerialPort.GetPortNames().Length} Com Ports!");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUSBDisplay(false);
            RefreshCOMPorts();

            for (int i = 1; i < 31; i++)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.Text = "0";


            for (int i = 0; i < 961; i++)
            {
                comboBox3.Items.Add(i);
            }

            checkBox1.Checked = Properties.Settings.Default.ShowPokemon;
            checkBox2.Checked = Properties.Settings.Default.UseSync;
            comboBox2.Text = Properties.Settings.Default.StartSlot;
            comboBox3.Text = Properties.Settings.Default.ReconnectAfter;
            
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            ApplyLog("Saving...");
            Properties.Settings.Default.UseSync = checkBox2.Checked;
            Properties.Settings.Default.ShowPokemon = checkBox1.Checked;
            Properties.Settings.Default.ReconnectAfter = comboBox3.Text;
            Properties.Settings.Default.StartSlot = comboBox2.Text;
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
                if(Status) 
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

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
