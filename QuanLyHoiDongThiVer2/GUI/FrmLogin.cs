using QuanLyHoiDongThiVer2.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoiDongThiVer2
{
    public partial class Form1 : Form
    {
        private MTA_QUIZ_Entities db = DAO.DBService.db;
        #region constructor
        public Form1()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }
        #endregion

        #region sự kiện
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            int cnt = db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.UserName == username && p.Password == password).ToList().Count;
            if (cnt == 0)
            {
                MessageBox.Show("Tài khoản không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ChucVu = (int) db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.UserName == username && p.Password == password).FirstOrDefault().ExaminationCouncil_PositionID;
            string MaChucVu = db.EXAMINATIONCOUNCIL_POSITIONS.Where(p => p.ExaminationCouncil_PositionID == ChucVu).FirstOrDefault().ExaminationCouncil_PositionCode;
            if (MaChucVu != "DT")
            {
                MessageBox.Show("Tài khoản không có quyền điểm trưởng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmMain tg = new FrmMain(db.EXAMINATIONCOUNCIL_STAFFS.Where(p=>p.UserName == username && p.Password == password).FirstOrDefault());
            this.Hide();
            tg.ShowDialog();
            this.Show();
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
        #endregion

    }
}
