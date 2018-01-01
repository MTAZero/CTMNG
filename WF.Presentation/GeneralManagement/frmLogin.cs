using GeneralManagement.Common;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralManagement
{
    public partial class frmLogin : MetroForm
    {
        ConfigApplication ca;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ca = new ConfigApplication();
            ErrorController rEC = new ErrorController();

            Encryption.Instance.DecryptConfigFile(Constant.PATH_CONFIG_FILE, Constant.PATH_CONFIG_FILE_TMP, out rEC);
            if (rEC.ErrorCode == Constant.STATUS_OK)
            {
                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | frmLogin_Load | DecryptConfigFile", Controllers.Instance.HandleStringErrorController(rEC));
                Controllers.Instance.GetConfigFile(out ca, out rEC);
                if (ca != null && rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | frmLogin_Load | GetConfigFile", Controllers.Instance.HandleStringErrorController(rEC));
                    AppConfig app = new AppConfig();
                    app.SaveConnectionString(app.AnalyzeConnectionString(ca), out rEC);
                    if (rEC.ErrorCode == Constant.STATUS_OK)
                    {
                        Encryption.Instance.EncryptConnectionString(out rEC);
                        if (rEC.ErrorCode == Constant.STATUS_OK)
                        {
                            if (Controllers.Instance.HandleCheckDB(ca.DBName, ca.Database.IP, ca.Database.Port, ca.UsernameDB, ca.PasswordDB))
                            {

                            }
                            else
                                {
                                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Properties.Resources.MSG_GUI_0061);
                                MessageBox.Show("Kiểm tra kết nối với server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                if (DialogResult == DialogResult.OK)
                                {
                                    this.Close();
                                }
                         }
                        }
                       
                    }
                }
            }
                            SetLocation();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        void SetLocation()
        {
            //this.pnlLogin.Left = (this.pnlCover.Width - this.pnlLogin.Width) / 2;
            //this.pnlLogin.Top = (this.pnlCover.Height - this.pnlLogin.Height) / 2 - 50;
        }

    
           

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int per = 0;
            if (Bus.BusALL.Instance.CheckLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim(), out per))
            {
                AppSession.UserName = txtUserName.Text.Trim();
                AppSession.Password = txtPassword.Text.Trim();
                AppSession.Permission = per;
                AppSession.StaffID = Bus.BusALL.Instance.GetInfoSupervisor(7).StaffID.Value;
                AppSession.LogTime = /*Convert.ToInt32(DatetimeConvert.ConvertDateTimeToUnix(DateTime.Now));*/ DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form frmSupervisorManage = new Supervisors.frmSupervisorManage(this);
                frmSupervisorManage.ShowDialog();
               
                    this.Show();
                
            
            }
            else
            {
                MessageBox.Show("Lỗi đăng nhập", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
            }
        }
    }
}
