using System.Windows.Forms;

namespace SwitchPokeBot
{

    class Program
    {
        public static bool botRunning { get; set; }
        public static bool botConnected { get; set; }
        public static Form1 form;

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form1();
            Application.Run(form);
        }
    }
}
