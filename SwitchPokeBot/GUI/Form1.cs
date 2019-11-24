using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SwitchPokeBot
{
    public partial class Form1 : Form
    {
        private string comPort = string.Empty;
        public bool Use_YT_Countdown { get; set; }
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
                    var sink = new SwitchInputSink(comPort, Convert.ToInt32(comboBox2.Text), Convert.ToInt32(comboBox3.Text), checkBox2.Checked);
                    SwitchPokeBot.Bot.Suprise_Bot suprise = new Bot.Suprise_Bot();
                    suprise.test();
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

        private void Form1_Load(object sender, EventArgs e)
        {

            RefreshCOMPorts();

            for (int i = 0; i < 30; i++)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.Text = "0";

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


        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            Program.botRunning = false;
            Environment.Exit(0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/wchill/SwitchInputEmulator");
        }


    }
}
