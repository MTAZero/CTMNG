using System.Threading;
using System.Windows.Forms;

namespace EXON.RegisterManager.Core
{
    public class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private ProgressBar progressBar2;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        private delegate void CloseDelegate();

        private static SplashForm splashForm;

        static public void ShowSplashScreen()
        {
            if (splashForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(SplashForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            splashForm = new SplashForm();
            Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            if (splashForm != null)
                splashForm.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            Thread.Sleep(200);
            splashForm.Close();
            splashForm = null;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar2
            // 
            this.progressBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar2.Location = new System.Drawing.Point(0, 0);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(530, 38);
            this.progressBar2.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SplashForm
            // 
            this.ClientSize = new System.Drawing.Size(530, 38);
            this.Controls.Add(this.progressBar2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            progressBar2.Value = progressBar2.Value == progressBar2.Maximum ? 0 : progressBar2.Value += 2;
        }
    }
}