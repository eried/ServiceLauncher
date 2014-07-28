using System;
using System.Windows.Forms;

namespace ServiceLauncher
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var f = new FormMain();
            f.FormLoad();

            Application.Run();
        }
    }
}