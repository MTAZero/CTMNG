using EXON.Main.Module;
using EXON.Main.Module.Forms;
using EXON.Main.Module.Report;
using System;
using System.Windows.Forms;

namespace EXON.Main
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}