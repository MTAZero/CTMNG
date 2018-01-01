using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zero.SinhDuLieuTuDong.Data;

namespace Zero.SinhDuLieuTuDong
{
    public partial class FrmMain : Form
    {
        private ExonSystem db = new ExonSystem();
        private CONTEST contest;

        #region Hàm khởi tạo
        public FrmMain(int ContestID)
        {
            InitializeComponent();

            contest = new CONTEST();
            contest = db.CONTESTS.Where(p => p.ContestID == ContestID).FirstOrDefault();
        }
        #endregion

        #region LoadForm
        private void LoadInformation()
        {
            txtTenKiThi.Text = contest.ContestName;
            txtSoCaThi.Text = db.SHIFTS.Where(p => p.ContestID == contest.ContestID && p.Status > 0).ToList().Count.ToString();
            txtSoMonThi.Text = db.SCHEDULES.Where(p => p.ContestID == contest.ContestID && p.Status > 0).ToList().Count.ToString();
            txtSoPhongThi.Text = (
                                    from dd in db.LOCATIONS.Where(p => p.Status > 0 && p.ContestID == contest.ContestID).ToList()
                                    from pt in db.ROOMTESTS.Where(p => p.Status > 0 && p.LocationID == dd.LocationID).ToList()
                                    select pt
                                  )
                                  .ToList()
                                  .Count
                                  .ToString();

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }
        #endregion

        #region  Hàm chức năng
        private bool Check()
        {
            if (txtTienToTenThiSinh.Text == "")
            {
                MessageBox.Show("Tiền tố tên thí sinh không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSoMonThiSinh.Value > Int32.Parse(txtSoMonThi.Text))
            {
                MessageBox.Show("Số môn thi của mỗi thí sinh tối đa bằng số môn thi của kì thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (contest.Status == 0)
            {
                MessageBox.Show("Kì thi chưa được phê duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (contest.Status == 3)
            {
                MessageBox.Show("Kì thi đã bị hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (contest.Status != 1)
            {
                DialogResult rs = MessageBox.Show("Kì thi đã được đăng ký\nBạn có chắc chắn sinh lại dữ liệu đăng ký cho kì thi?",
                                                  "Thông báo",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Question);
                if (rs == DialogResult.Cancel) return false;
            }

            return true;
        }
        #endregion


        #region Sự kiện
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSinhDuLieu_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (contest.Status != 1) Helper.XoaDuLieuDangKy(contest);
                Helper.SinhDuLieuDangKy(contest, (int) txtSoThiSinh.Value, (int) txtSoMonThiSinh.Value, txtTienToTenThiSinh.Text);

                db = new ExonSystem();

                MessageBox.Show("Sinh dữ liệu đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        #endregion
    }
}
