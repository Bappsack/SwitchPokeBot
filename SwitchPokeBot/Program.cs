using System.Windows.Forms;

namespace SwitchPokeBot
{

    class Program
    {
        public static bool botRunning { get; set; }
        public static bool botConnected { get; set; }
        public static Form1 form;
        public static SwitchInputSink switchInput;

        public static void Main(string[] args)
        {
            form = new Form1();
            Application.Run(form);
        }
    }
}
