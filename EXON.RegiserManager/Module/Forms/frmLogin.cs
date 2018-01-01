using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EOS.Main.Module.Forms
{
    public partial class FrmLogin : Form
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
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(EXON.RegisterManager.Properties.Resources.NotInputMessage, EXON.RegisterManager.Properties.Resources.Error);
                    return;
                }
                else
                {
                    if (_StaffService.Login(txtUsername.Text, txtPassword.Text))
                    {
                        LoginStatus = LoginStatus.Login;
                        int StaffId = 0;
                            StaffId= _StaffService.GetIdByUserPass(txtUsername.Text, txtPassword.Text);
                        STAFF staff = _StaffService.GetById(StaffId);
                        List<STAFFS_POSITIONS> lstposition = staff.STAFFS_POSITIONS.ToList();
                        int kt = 0;
                        foreach (STAFFS_POSITIONS item in lstposition)
                        {
                            if (item.POSITION.PositionCode == "CBTN")
                            {
                                kt = 1;
                                break;
                            }
                        }
                        if (kt == 1)
                        {
                            CurrentStaffId = StaffId;
                            this.Hide();
                        }
                            
                        else
                            MessageBox.Show("Tên đăng nhập không có quyền cán bộ tiếp nhận");
                    }
                    else
                    {
                        MessageBox.Show(EXON.RegisterManager.Properties.Resources.NotLoginMessage, EXON.RegisterManager.Properties.Resources.Notification);
                        txtPassword.Text = string.Empty;
                    }
                }
            }
            catch
            {
                MessageBox.Show(EXON.RegisterManager.Properties.Resources.NotConnectServerMessage, EXON.RegisterManager.Properties.Resources.Error);
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