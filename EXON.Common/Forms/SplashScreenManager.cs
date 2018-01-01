using MetroFramework.Forms;
using System.Threading;
using System.Windows.Forms;

namespace EXON.Common
{
    public partial class SplashScreenManager : MetroForm
    {
        public SplashScreenManager()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private delegate void CloseDelegate();

        private static SplashScreenManager splashForm;

        static public void ShowSplashScreen()
        {
            if (splashForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(SplashScreenManager.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            splashForm = new SplashScreenManager();
            Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            Thread.Sleep(200);
            if (splashForm != null)
                splashForm.Invoke(new CloseDelegate(SplashScreenManager.CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            splashForm.Close();
            splashForm = null;
        }
    }
}