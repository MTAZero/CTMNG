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
    public partial class FrmMain : Form
    {
        #region constructor
        private StaffDTO user = new StaffDTO();
        public FrmMain()
        {
            InitializeComponent();
            user = DAO.AcountDAO.NguoiDung(2);
        }

        public FrmMain(StaffDTO _user)
        {
            InitializeComponent();
            user = _user;
        }
        public FrmMain(string _user,string _pass)
        {
           
            InitializeComponent();
            int ma = DAO.AcountDAO.DangNhap(_user, _pass);
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
            user = nguoidung;
        }
        #endregion

        #region sự kiện mở các hàm chức năng

        private void btnDonVi_Click(object sender, EventArgs e)
        {
            FrmDonVi donvi = new FrmDonVi();
            donvi.TopLevel = false;
            donvi.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(donvi);
            donvi.Show();
        }
        

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            FrmChucVu tg = new FrmChucVu();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }
        

        private void btnHocHamHocVi_Click(object sender, EventArgs e)
        {
            FrmChucVuCanBo tg = new FrmChucVuCanBo();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void btnCanBo_Click(object sender, EventArgs e)
        {
            FrmCanBo tg = new FrmCanBo();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void btnHocPhan_Click(object sender, EventArgs e)
        {
            FrmHocPhan tg = new FrmHocPhan();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void btnLoaiCauHoi_Click(object sender, EventArgs e)
        {
            FrmLoaiCauHoi tg = new FrmLoaiCauHoi();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void btnLoaiViPham_Click(object sender, EventArgs e)
        {
            FrmLoaiViPham tg = new FrmLoaiViPham();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void btnChucVuHoiDongThi_Click(object sender, EventArgs e)
        {
            FrmChucVuHoiDongThi tg = new FrmChucVuHoiDongThi();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }
        #endregion

        
    }
}
