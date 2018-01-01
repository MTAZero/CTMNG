using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamManagement.GUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        #region sự kiện
        private void btnThietLapCSDL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKetNoiCSDL ketnoi = new FrmKetNoiCSDL();
            ketnoi.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string TenDangNhap = txtTenDangNhap.Text;
            string MatKhau = txtMatKhau.Text;

            if (!DAO.SqlServerHelper.KiemTraKetNoi())
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thất bại! Chọn thiết lập CSDL để thiết lập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ma = DAO.AcountDAO.DangNhap(TenDangNhap, MatKhau);

            if (ma == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu chưa chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var query = (from pc in DAO.Staffs_PositionDAO.DanhSach().ToList()
                         from quyen in DAO.PositionDAO.DanhSach().ToList()
                         where pc.PositionID == quyen.PositionID
                         where pc.StaffID == ma
                         where quyen.PositionCode == "ADMIN"
                         select quyen).ToList().Count();
            int kt = (int)query;

            if (kt == 0)
            {
                MessageBox.Show("Người dùng không có quyền Administrator để đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StaffDTO nguoidung = DAO.AcountDAO.NguoiDung(ma);
            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmMain frmMain = new FrmMain(nguoidung);

            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            this.Hide();
            frmMain.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        #endregion

        
    }
}
