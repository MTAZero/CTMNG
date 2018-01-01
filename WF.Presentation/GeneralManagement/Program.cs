using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Supervisors.frmSupervisorManage(7));
         
           // Application.Run(new Camera.frmCamera());
            ///Application.Run(new RM.GetFinger.frmGetFingerPrinter());

        }
    }
}
