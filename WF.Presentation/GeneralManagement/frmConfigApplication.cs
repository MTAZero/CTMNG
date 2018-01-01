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
using GeneralManagement.Common;
namespace GeneralManagement
{
    public partial class frmConfigApplication : Form
    {
        private BackgroundWorker m_oWorker;
        public delegate void SendWorking(string data);
        public delegate void SendControl(List<Label> lstControl);
        private List<Label> lstLabel;
        ConfigApplication ca;
        public frmConfigApplication()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
                DTO.frmServer = new Supervisors.frmSupervisorServer(); 


        }

        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //DTO.WaitingForm.Hide();
            //m_oWorker.Dispose();
        }
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (e.ProgressPercentage == 100)
            //{
            //    Thread.Sleep(300);
            //    DTO.WaitingForm.Hide();
            //    this.Hide();
            //    DTO.LoginForm.Show();
            //}
         }
        private void button1_Click(object sender, EventArgs e)
        {
            string dbName = Properties.Resources.DB_NAME;
            int dbPort = int.Parse(Properties.Resources.DB_PORT);
            string dbUser = Properties.Resources.DB_USER;
            string dbPass = Properties.Resources.DB_PASS;
            if (Common.Controllers.Instance.HandleCheckDB(dbName, txtIP.Text, dbPort, dbUser, dbPass))
            {
                ErrorController rEC = new ErrorController();
                ca = new ConfigApplication();
                ca.Database = new IPConfig(txtIP.Text,dbPort);
                ca.DBName = dbName;
                ca.UsernameDB = dbUser;
                ca.PasswordDB = dbPass;
                ca.Password = Constant.ENCRYPT_PASS_HASH;
                Controllers.Instance.GenerateConfigFile(ca, out rEC);
                AppConfig app = new AppConfig();
                //app.SaveConnectionString(app.AnalyzeConnectionString(ca), out rEC);
                if (rEC.ErrorCode == 1)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "CONFIGAPPLICATION | BUTTON_SUBMIT_CLICK | GenerateConfigFile", Controllers.Instance.HandleStringErrorController(rEC));
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                    this.Hide();
                }
                else
                {
                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                    this.Close();
                }
                }
            else
            {
                MessageBox.Show("Không thể kết nối dữ liệu");
            }
            //m_oWorker.RunWorkerAsync();
            //SendControl SC = new SendControl(DTO.WaitingForm.HandleLoadingControl);
            //SC(lstLabel);
            //DTO.WaitingForm.Owner = this;
            //DTO.WaitingForm.ShowDialog();
        }

     

        private void frmConfigApplication_Load(object sender, EventArgs e)
        {
            if (File.Exists(Constant.PATH_CONFIG_FILE))
            {
                
                            this.Hide();             
                            frmLogin frm = new frmLogin();
                            frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kiểm tra kết nối với server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
        }
    

