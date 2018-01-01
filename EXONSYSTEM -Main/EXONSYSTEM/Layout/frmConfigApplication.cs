using DAO.DataProvider;
using EXONSYSTEM.Common;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXONSYSTEM.Layout
{
	public partial class frmConfigApplication : MetroForm
	{
		private BackgroundWorker m_oWorker;
		public delegate void SendWorking(string data);
		public delegate void SendControl(List<Label> lstControl);
		private List<Label> lstLabel;
       private ConfigApplication CA;
        public delegate void SendConfigToAuthen(ConfigApplication ca);
		public frmConfigApplication()
		{
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();

			pnContent.Left = (this.Width - pnContent.Width) / 2;
			lbSupervisor.Location = new Point((pnContent.Width - lbSupervisor.Width) / 2, 0);
			lbLine1.Location = new Point(0, lbSupervisor.Bottom + 10);
			lbLine1.BackColor = lbLine2.BackColor = Constant.BACKCOLOR_PANEL_WELCOME;
			pnSupervisor.Location = new Point(0, lbLine1.Bottom + 10);
			lbDB.Location = new Point((pnContent.Width - lbDB.Width) / 2, pnSupervisor.Bottom);
			lbLine2.Location = new Point(0, lbDB.Bottom + 10);
			pnDB.Location = new Point(0, lbLine2.Bottom);
			btnSubmit.ForeColor = Constant.FORCECOLOR_BUTTON_SUBMIT;
			btnSubmit.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;
			btnSubmit.Location = new Point((this.Width - btnSubmit.Width) / 2, pnContent.Bottom);
			mtxbIPSupervisor.Focus();
			DTO.MainForm = new frmMainForm();
			DTO.LoadingForm = new frmLoading();
			DTO.NotificationForm = new frmNotification();
			DTO.LoginForm = new frmAuthentication();
			DTO.WaitingForm = new frmWaiting();

			m_oWorker = new BackgroundWorker();
            
			m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
			m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
			m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorker_RunWorkerCompleted);
			m_oWorker.WorkerReportsProgress = true;
           
            
        }

        public void runwork()

        {
            m_oWorker.RunWorkerAsync();
            SendControl SC = new SendControl(DTO.WaitingForm.HandleLoadingControl);
            lstLabel = new List<Label>();
            Label lbSuper = new Label();
            lbSuper.Name = "lbSuper";
            lbSuper.AutoSize = true;
            lbSuper.ForeColor = Constant.COLOR_BLACK;
            lbSuper.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 12, FontStyle.Bold);
            lbSuper.Text = "Kiểm tra kết nối với máy giám thị";

            lstLabel.Add(lbSuper);
            Label lbDB = new Label();
            lbDB.Name = "lbDB";
            lbDB.AutoSize = true;
            lbDB.ForeColor = Constant.COLOR_BLACK;
            lbDB.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 12, FontStyle.Bold);
            lbDB.Text = "Kiểm tra kết nối với máy chủ";
            lstLabel.Add(lbDB);
            SC(lstLabel);
            DTO.WaitingForm.Owner = this;
            DTO.WaitingForm.ShowDialog();
        }
        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DTO.WaitingForm.Hide();
			m_oWorker.Dispose();
		}
		void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage == 100)
			{
				Thread.Sleep(300);
				DTO.WaitingForm.Hide();
				
                SendConfigToAuthen sd = new SendConfigToAuthen(DTO.LoginForm.HandelInformationFromFrmConfig);
                sd(CA);
				DTO.LoginForm.Show();
			}
		}
		void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
		{
            string DBName = Properties.Resources.DATABASE_NAME;
            string DBUser = Properties.Resources.USER_DATABASE;
            int portSupervisor = Convert.ToInt32(Properties.Resources.PORT_SUPER);
            int portDB = Convert.ToInt32(Properties.Resources.PORT_DATABASE);
            string PsDB = Properties.Resources.PASS_DATABASE;
            string Ip_Db = Properties.Resources.IP_DB;
            string ip_super = Properties.Resources.IP_SUPERVISOR;
            SendWorking s = new SendWorking(DTO.WaitingForm.HandleWorking);
			m_oWorker.ReportProgress(0);
			if (ValidateChildren(ValidationConstraints.Enabled))
			{
                if (!Controllers.Instance.HandleCheckConnection(ip_super, portSupervisor))
                {
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Properties.Resources.MSG_GUI_0060, this);
                    Environment.Exit(0);
                    Application.Exit();
                }
                else
                {
                    s("lbSuper");
                    m_oWorker.ReportProgress(50);
                    if (Controllers.Instance.HandleCheckConnection(ip_super, portSupervisor))
                    {
                        if (Controllers.Instance.HandleCheckDB(DBName, Ip_Db, portDB, DBUser, PsDB))
                        {
                            s("lbDB");
                            ErrorController rEC = new ErrorController();
                            CA = new ConfigApplication();
                            CA.Supervisor = new IPConfig(ip_super,portSupervisor);
                            CA.Database = new IPConfig(Ip_Db, portDB);
                            CA.DBName = DBName;
                            CA.UsernameDB = DBUser;
                            CA.PasswordDB = PsDB;
                            CA.Password = Constant.ENCRYPT_PASS_HASH;
                            // Controllers.Instance.GenerateConfigFile(CA, out rEC);
                            //if (rEC.ErrorCode == Constant.STATUS_OK)
                            //{
                            //    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "CONFIGAPPLICATION | BUTTON_SUBMIT_CLICK | GenerateConfigFile", Controllers.Instance.HandleStringErrorController(rEC));
                            //    m_oWorker.ReportProgress(100);
                            //}
                            //else
                            //{
                            //    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                            //    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                            //    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                            //}
                            m_oWorker.ReportProgress(100);
                        }
                        else
                        {
                            Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Properties.Resources.MSG_GUI_0061);
                            Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Properties.Resources.MSG_GUI_0061, this);
                            Environment.Exit(0);
                            Application.Exit();
                        }
                    }
                    else
					{
						Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Properties.Resources.MSG_GUI_0061);
						Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Properties.Resources.MSG_GUI_0061, this);
                        Environment.Exit(0);
                        Application.Exit();
					}
				}
			}
		}
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			//m_oWorker.RunWorkerAsync();
			SendControl SC = new SendControl(DTO.WaitingForm.HandleLoadingControl);
			SC(lstLabel);
			DTO.WaitingForm.Owner = this;
			DTO.WaitingForm.ShowDialog();
		}
		private void mtxb_Validating(object sender, CancelEventArgs e)
		{
            MetroTextBox mtxb = sender as MetroTextBox;
            if (mtxb.Name.Contains("IP"))
            {
                string[] arrString = mtxb.Text.Split('.');
                if (!mtxb.Text.Contains('.') || arrString.Length != 4 || (arrString.Length == 4 && arrString[3].Length == 0))
                {
                    e.Cancel = true;
                    errorProvider.SetError(mtxb, Properties.Resources.MSG_GUI_0062);
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(mtxb, null);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(mtxb.Text) || string.IsNullOrWhiteSpace(mtxb.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(mtxb, Properties.Resources.MSG_GUI_0059);
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(mtxb, null);
                }
            }
        }
		private void mtxb_KeyPress(object sender, KeyPressEventArgs e)
		{
			int count = 0;
			MetroTextBox mtbx = sender as MetroTextBox;
			if (mtbx.Name.Contains("Port"))
			{
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
				{
					e.Handled = true;
				}
			}
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                // only allow one decimal point
                if (e.KeyChar == '.' && (sender as MetroTextBox).Text.Split('.').Length > 3)
                {
                    count++;
                    if (count < 4)
                    {
                        e.Handled = true;
                    }
                }
                string[] arrText = (sender as MetroTextBox).Text.Split('.');
                if (!char.IsControl(e.KeyChar) && arrText.Length == 4 && arrText[3].Length == 3)
                {
                    e.Handled = true;
                }
            }
        }

		private void frmConfigApplication_Load(object sender, EventArgs e)
		{
            CheckConnect();
		}

        private void CheckConnect()
        {
            //if (File.Exists(Constant.PATH_CONFIG_FILE))
            //{
                DTO.LoginForm.Show();
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Hide();
            //}
            //else
            //{
                //lstLabel = new List<Label>();
                //Label lbSuper = new Label();
                //lbSuper.Name = "lbSuper";
                //lbSuper.AutoSize = true;
                //lbSuper.ForeColor = Constant.COLOR_BLACK;
                //lbSuper.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 12, FontStyle.Bold);
                //lbSuper.Text = "Kiểm tra kết nối với máy giám thị";

                //lstLabel.Add(lbSuper);
                //Label lbDB = new Label();
                //lbDB.Name = "lbDB";
                //lbDB.AutoSize = true;
                //lbDB.ForeColor = Constant.COLOR_BLACK;
                //lbDB.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 12, FontStyle.Bold);
                //lbDB.Text = "Kiểm tra kết nối với máy chủ";
                //lstLabel.Add(lbDB);
        //    }
        }

     //   int count = 0;
		private void mtxb_TextChanged(object sender, EventArgs e)
		{
			//MetroTextBox mt = (sender as MetroTextBox);
			//count++;
			//if (count == 3 && mt.Text.Split('.').Length < 4)
			//{
			//	mt.Text += ".";
			//	mt.SelectionStart = mtxbIPDatabase.Text.Length;
			//}
			//if (mt.Text.EndsWith(".") || mt.Text.Trim().Length == 0)
			//{
			//	count = 0;
			//}
		}

        private void lbDB_Click(object sender, EventArgs e)
        {

        }
    }
}
