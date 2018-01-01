using EXON.Common;
using EXON.Data.Services;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace EXON.Main.Module.Forms
{
    public partial class FrmLogin : MetroForm
    {
        private StaffService _StaffService;

        public LoginStatus LoginStatus
        {
            get;
            private set;
        }

        public int CurrentStaffId
        {
            get;
            private set;
        }

        public FrmLogin()
        {
            _StaffService = new StaffService();
            InitializeComponent();
            LoginStatus = LoginStatus.None;
            this.ControlBox = false;
            //txtUsername.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(Properties.Resources.NotInputMessage, Properties.Resources.Error);
                    return;
                }
                else
                {
                    if (_StaffService.Login(txtUsername.Text, txtPassword.Text))
                    {
                        LoginStatus = LoginStatus.Login;
                        CurrentStaffId = _StaffService.GetIdByUserPass(txtUsername.Text, txtPassword.Text);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.NotLoginMessage, Properties.Resources.Notification);
                        txtPassword.Text = string.Empty;
                    }
                }
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(Properties.Resources.NotConnectServerMessage, Properties.Resources.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            LoginStatus = LoginStatus.Close;
            this.Close();
        }

        private void ceHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ceHienMatKhau.Checked)
                txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '*';
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://web.facebook.com/help/374104332645037?helpref=faq_content");
        }
    }
}