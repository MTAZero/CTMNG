using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.DAO;
using ContestManagementVer2.Report;
using MetroFramework;
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
    public partial class FrmLapKeHoachThi : MetroForm
    {
        private STAFF nhanvien = new STAFF();
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region Constructor
        public FrmLapKeHoachThi(STAFF _nv)
        {
            InitializeComponent();
            nhanvien = _nv;
            DAO.DBService.Reload();
        }

        #endregion

        #region LoadForm

        private void LoadInitControl()
        {
            // trạng thái trên panel thông tin kì thi
            txtContestName.Text = "";

            // trạng thái các button   
            btnMonThi.Enabled = false;
            btnCaThi.Enabled = false;
            btnDiaDiem.Enabled = false;
            btnPhanCongHDT.Enabled = false;
            btnKiemTraKeHoach.Enabled = false;
            btnHoanThanhKeHoach.Enabled = false;

            // các datetime mặc định
            dateCreatedDate.Value = DateTime.Now;
            dateBeginRegistration.Value = DateTime.Now.AddMinutes(10);
            dateEndRegistration.Value = DateTime.Now.AddMinutes(29);
            dateCreatedQuestionStartDate.Value = DateTime.Now.AddMinutes(30);
            dateCreatedQuestionEndDate.Value = DateTime.Now.AddMinutes(49);
            dateBeginDate.Value = DateTime.Now.AddMinutes(50);
            dateEndDate.Value = DateTime.Now.AddMinutes(69);

            // panel chính
            panelChinh.Controls.Clear();

            // cbx contestname
            txtContestName.SelectedIndex = 0;

        }

        private void FrmLapKeHoachThi_Load(object sender, EventArgs e)
        {
            LoadInitControl();
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
                btnHoanThanhKeHoach.Enabled = false;


                return;
            }

            if (btnSua.Text == "Lưu thông tin thời gian")
            {
                if (Check())
                {
                    /// từ đây tên k được sửa
                    txtContestName.Enabled = false;

                    // Người dùng sau khi nhập xong thông tin của kì thi thì enable các menu chức năng
                    btnSua.Text = "Sửa thông tin thời gian";

                    btnMonThi.Enabled = true;
                    btnCaThi.Enabled = true;
                    btnDiaDiem.Enabled = true;
                    btnPhanCongHDT.Enabled = true;
                    btnKiemTraKeHoach.Enabled = true;
                    btnHoanThanhKeHoach.Enabled = true;

                    panelThongTinKiThi.Enabled = false;
                    panelChinh.Enabled = true;

                    CONTEST tg = getContestByForm();
                    //kithi.ContestName = tg.ContestName;

                    kithi.CreatedDate = tg.CreatedDate;
                    kithi.BeginDate = tg.BeginDate;
                    kithi.EndDate = tg.EndDate;
                    kithi.CreatedQuestionStartDate = tg.CreatedQuestionStartDate;
                    kithi.CreatedQuestionEndDate = tg.CreatedQuestionEndDate;
                    kithi.BeginRegistration = tg.BeginRegistration;
                    kithi.EndRegistration = tg.EndRegistration;

                    kithi.CreatedStaffID = tg.CreatedStaffID;

                    if (kithi.ContestID == 0)
                    {
                        kithi.ContestName = tg.ContestName + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        db.CONTESTS.Add(kithi);

                        try
                        {
                            db.SaveChanges();
                            CONTEST_FEES ctf = new CONTEST_FEES();
                            ctf.ContestID = kithi.ContestID;
                            ctf.Year = DateTime.Now.Year;
                            ctf.Cost = 0;
                            ctf.Status = 1;
                            ctf.FreeType = 1;
                            ctf.Unit = "VNĐ";
                            db.CONTEST_FEES.Add(ctf);
                        }
                        catch
                        {

                        }
                    }

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

        private void btnDiaDiem_Click(object sender, EventArgs e)
        {
            ucThemDiaDiemPhongThi uc = new ucThemDiaDiemPhongThi(kithi);
            panelChinh.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelChinh.Controls.Add(uc);
        }

        private void btnPhanCongHDT_Click(object sender, EventArgs e)
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

        private void btnHoanThanhKeHoach_Click(object sender, EventArgs e)
        {
            if (CheckKiThi(kithi))
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn hoàn thành kế hoạch",
                                "Thông báo",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                MessageBox.Show("Lập kế hoạch thành công",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.Close();
            }

            return;
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

            ans.CreatedStaffID = nhanvien.StaffID;

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
