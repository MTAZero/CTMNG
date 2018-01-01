using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class FrmMain : Form
    {
        private MTA_QUIZ_Entities db = DAO.DBService.db;
        private EXAMINATIONCOUNCIL_STAFFS tg = new EXAMINATIONCOUNCIL_STAFFS();

        #region constructor
        public FrmMain()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmMain(string userName)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            /// de chay thu
            tg = db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.UserName.Contains(userName)).FirstOrDefault();
        }

        public FrmMain(int id)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            tg = db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.StaffID == id).FirstOrDefault();
            

        }

        public FrmMain(EXAMINATIONCOUNCIL_STAFFS es)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            tg = es;
        }
        #endregion


        #region sự kiện
        private void PhanCongGiamThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhanCongGiamThi tgz = new FrmPhanCongGiamThi(db.LOCATIONS.Where(p=>p.LocationID == tg.LocationID).FirstOrDefault());
            tgz.TopLevel = false;
            tgz.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tgz);
            tgz.Show();
        }

        private void TrangThaiDiaDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrangThaiDiaDiem tgz = new FrmTrangThaiDiaDiem(db.LOCATIONS.Where(p=>p.LocationID == tg.LocationID).FirstOrDefault());
            tgz.TopLevel = false;
            tgz.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tgz);
            tgz.Show();
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Đồng chí có chắc chắn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.Cancel) return;
            this.Close();
        }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau frm = new FrmDoiMatKhau(tg);
            frm.ShowDialog();
        }
        #endregion

        #region LoadForm
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (tg == null)
            {
                MessageBox.Show("Không có quyền điểm trưởng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            txtContestName.Text = db.CONTESTS.Where(p => p.ContestID == tg.ContestID).FirstOrDefault().ContestName.ToUpper();
            txtLocationName.Text = db.LOCATIONS.Where(p => p.LocationID == tg.LocationID).FirstOrDefault().LocationName.ToUpper();
            txtStaffName.Text = db.STAFFS.Where(p => p.StaffID == tg.StaffID).FirstOrDefault().FullName.ToUpper();
        }
        #endregion

        


    }
}
