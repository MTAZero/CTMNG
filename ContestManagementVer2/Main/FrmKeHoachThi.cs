using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.DAO;
using ContestManagementVer2.Report;
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

namespace ContestManagementVer2.Main
{
    public partial class FrmKeHoachThi : MetroForm
    {
        private STAFF nhanvien = new STAFF();
        private CONTEST kithi = new CONTEST();
        private ExonSystem db = DAO.DBService.db;

        #region constructor
        public FrmKeHoachThi(STAFF _nv, CONTEST _kt)
        {
            InitializeComponent();
            nhanvien = _nv;
            kithi = _kt;
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void LoadChinhSua()
        {
            // load các button
            btnSua.Visible = false;

            btnMonThi.Visible = true;
            btnCaThi.Visible = true;
            btnDiaDiem.Visible = true;
            btnPhanCongHDT.Visible = true;

            btnKiemTraKeHoach.Visible = true;
            btnLuuKeHoach.Visible = false;
            btnXacNhanPheDuyetKeHoach.Visible = false;

            panelThongTinKiThi.Enabled = false;

            txtContestName.Text = kithi.ContestName;
            dateCreatedDate.Value = Helper.ConvertUnixToDateTime((int)kithi.CreatedDate);
            dateBeginRegistration.Value = Helper.ConvertUnixToDateTime((int)kithi.BeginRegistration);
            dateEndRegistration.Value = Helper.ConvertUnixToDateTime((int)kithi.EndRegistration);
            dateCreatedQuestionStartDate.Value = Helper.ConvertUnixToDateTime((int)kithi.CreatedQuestionStartDate);
            dateCreatedQuestionEndDate.Value = Helper.ConvertUnixToDateTime((int)kithi.CreatedQuestionEndDate);
            dateBeginDate.Value = Helper.ConvertUnixToDateTime((int)kithi.BeginDate);
            dateEndDate.Value = Helper.ConvertUnixToDateTime((int)kithi.EndDate);

            panelChinh.Enabled = true;
        }
        private void LoadPheDuyet()
        {
            btnSua.Visible = true;

            btnMonThi.Visible = true;
            btnCaThi.Visible = true;
            btnDiaDiem.Visible = true;
            btnPhanCongHDT.Visible = true;

            btnKiemTraKeHoach.Visible = true;
            btnLuuKeHoach.Visible = true;
            btnXacNhanPheDuyetKeHoach.Visible = false;
        }
        private void LoadTruongPhongKhaoThi()
        {
            btnXacNhanPheDuyetKeHoach.Visible = true;
        }

        private bool TruongPhongKhaoThi(STAFF nhanvien)
        {
            int cnt = (from nv in db.STAFFS.Where(p=>p.StaffID == nhanvien.StaffID).ToList()
                   from cv in db.POSITIONS.ToList()
                   from pc in db.STAFFS_POSITIONS.ToList()
                   where pc.StaffID == nv.StaffID
                   where pc.PositionID == cv.PositionID
                   where cv.PositionCode.ToUpper().Contains("TPKT")
                   select nv
                  ).ToList().Count();

            return cnt>0;
        }

        private void LoadForm()
        {
            LoadChinhSua();
            if (kithi.Status == 0) LoadPheDuyet();
            if (kithi.Status == 0 && TruongPhongKhaoThi(nhanvien)) LoadTruongPhongKhaoThi();
        }
        private void FrmKeHoachThi_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        #endregion

        #region Sự kiện
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa thông tin thời gian")
            {
                // chuyển sự tập trung của người dùng vào form thông tin
                btnSua.Text = "Lưu thông tin thời gian";

                panelThongTinKiThi.Enabled = true;
                panelChinh.Enabled = false;

                btnMonThi.Enabled = false;
                btnCaThi.Enabled = false;
                btnDiaDiem.Enabled = false;
                btnPhanCongHDT.Enabled = false;
                btnKiemTraKeHoach.Enabled = false;
                btnLuuKeHoach.Enabled = false;
                btnXacNhanPheDuyetKeHoach.Enabled = false;


                return;
            }

            if (btnSua.Text == "Lưu thông tin thời gian")
            {
                if (Check())
                {
                    // Người dùng sau khi nhập xong thông tin của kì thi thì enable các menu chức năng
                    btnSua.Text = "Sửa thông tin thời gian";

                    btnMonThi.Enabled = true;
                    btnCaThi.Enabled = true;
                    btnDiaDiem.Enabled = true;
                    btnPhanCongHDT.Enabled = true;
                    btnKiemTraKeHoach.Enabled = true;
                    btnLuuKeHoach.Enabled = true;
                    btnXacNhanPheDuyetKeHoach.Enabled = true;

                    panelThongTinKiThi.Enabled = false;
                    panelChinh.Enabled = true;

                    CONTEST tg = getContestByForm();
                    kithi.ContestName = tg.ContestName;

                    kithi.CreatedDate = tg.CreatedDate;
                    kithi.BeginDate = tg.BeginDate;
                    kithi.EndDate = tg.EndDate;
                    kithi.CreatedQuestionStartDate = tg.CreatedQuestionStartDate;
                    kithi.CreatedQuestionEndDate = tg.CreatedQuestionEndDate;
                    kithi.BeginRegistration = tg.BeginRegistration;
                    kithi.EndRegistration = tg.EndRegistration;

                    if (kithi.ContestID == 0)
                        db.CONTESTS.Add(kithi);

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Lưu thông tin kì thi thành công",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lưu thông tin kì thi thất bại\n" + ex.Message,
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                return;
            }
        }

        private void btnMonThi_Click(object sender, EventArgs e)
        {
            ucThemMonThi uc = new ucThemMonThi(kithi);
            panelChinh.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelChinh.Controls.Add(uc);
        }

        private void btnCaThi_Click(object sender, EventArgs e)
        {
            ucThemCaThi uc = new ucThemCaThi(kithi);
            panelChinh.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelChinh.Controls.Add(uc);
        }

        private void btnDiaDiemPhongThi_Click(object sender, EventArgs e)
        {
            ucThemDiaDiemPhongThi uc = new ucThemDiaDiemPhongThi(kithi);
            panelChinh.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelChinh.Controls.Add(uc);
        }

        private void btnPhanCongHoiDongThi_Click(object sender, EventArgs e)
        {
            ucThemPhanCongHoiDongThi uc = new ucThemPhanCongHoiDongThi(kithi);
            panelChinh.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelChinh.Controls.Add(uc);
        }

        private void btnKiemTraKeHoach_Click(object sender, EventArgs e)
        {
            FrmRpKeHoachKiThi form = new FrmRpKeHoachKiThi(kithi);
            form.ShowDialog();
        }

        private void btnLuuKeHoach_Click(object sender, EventArgs e)
        {
            if (CheckKiThi(kithi))
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn Lưu kế hoạch",
                                "Thông báo",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                MessageBox.Show("Lưu kế hoạch thành công",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.Close();
            }

            return;
        }

        private void btnXacNhanPheDuyetKeHoach_Click(object sender, EventArgs e)
        {
            if (CheckKiThi(kithi))
            {
                FrmXacNhanPheDuyetKeHoach form = new FrmXacNhanPheDuyetKeHoach(kithi, nhanvien);
                form.ShowDialog();
                LoadForm();
            }
        }
        #endregion

        #region Hàm chức năng

        private bool CheckKiThi(CONTEST kithi)
        {
            string MS = "";
            bool ans = DAO.Helper.CheckContest(kithi, ref MS);

            if (ans == false)
            {
                MessageBox.Show(MS, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return ans;
        }

        private bool Check()
        {
            // Kiểm tra thông tin người dùng nhập

            if (txtContestName.Text == "")
            {
                MessageBox.Show("Tên kì thi không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateBeginRegistration.Value < dateCreatedDate.Value)
            {
                MessageBox.Show("Thời gian bắt đầu đăng ký phải lớn hơn thời gian tạo kì thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateEndRegistration.Value < dateBeginRegistration.Value)
            {
                MessageBox.Show("Thời gian kết thúc đăng ký phải lớn hơn thời gian bắt đầu đăng ký",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateCreatedQuestionStartDate.Value < dateEndRegistration.Value)
            {
                MessageBox.Show("Thời gian bắt đầu làm đề thi phải lớn hơn thời gian kết thúc đăng ký",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateCreatedQuestionEndDate.Value < dateCreatedQuestionStartDate.Value)
            {
                MessageBox.Show("Thời gian kết thúc tạo đề thi phải lớn hơn thời gian bắt đầu tạo đề thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateBeginDate.Value < dateCreatedQuestionEndDate.Value)
            {
                MessageBox.Show("Thời gian bắt đầu thi phải lớn hơn thời gian kết thúc tạo câu hỏi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateEndDate.Value < dateBeginDate.Value)
            {
                MessageBox.Show("Thời gian kết thúc thi phải lớn hơn thời gian bắt đầu thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private CONTEST getContestByForm()
        {
            CONTEST ans = new CONTEST();

            ans.BeginRegistration = Helper.ConvertDateTimeToUnix(dateBeginRegistration.Value);
            ans.EndRegistration = Helper.ConvertDateTimeToUnix(dateEndRegistration.Value);
            ans.CreatedQuestionStartDate = Helper.ConvertDateTimeToUnix(dateCreatedQuestionStartDate.Value);
            ans.CreatedQuestionEndDate = Helper.ConvertDateTimeToUnix(dateCreatedQuestionEndDate.Value);
            ans.BeginDate = Helper.ConvertDateTimeToUnix(dateBeginDate.Value);
            ans.EndDate = Helper.ConvertDateTimeToUnix(dateEndDate.Value);
            ans.CreatedDate = Helper.ConvertDateTimeToUnix(dateCreatedDate.Value);

            ans.ContestName = txtContestName.Text;

            return ans;
        }

        #endregion


    }
}
