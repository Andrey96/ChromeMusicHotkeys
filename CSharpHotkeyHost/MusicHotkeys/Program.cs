using System;
using System.Threading;
using System.Windows.Forms;

namespace MusicHotkeys
{
    static class Program
    {
        public static Config FileConfig;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
