using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContestManagementVer2.CSDL_Exonsytem;

namespace ContestManagementVer2.Main
{
    public partial class ucThemPhanCongHoiDongThi : UserControl
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();
        private int indexHoiDongThi = 0, indexHoiDongThi1 = 0;

        #region Hàm khởi tạo
        public ucThemPhanCongHoiDongThi(CONTEST _ct)
        {
            InitializeComponent();
            kithi = _ct;
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void InitControlHoiDongThi()
        {
            // cbx can bo
            cbxCanBoHoiDongThi.DataSource = db.STAFFS.Where(p => p.Status == 1).ToList();
            cbxCanBoHoiDongThi.DisplayMember = "FullName";
            cbxCanBoHoiDongThi.ValueMember = "StaffID";

            // cbx chuc vu hoi dong thi
            cbxChucVuHoiDongThi.DataSource = db.EXAMINATIONCOUNCIL_POSITIONS
                                             .Where(p => p.Status == 1)
                                             .ToList();
            cbxChucVuHoiDongThi.DisplayMember = "ExaminationCouncil_PositionName";
            cbxChucVuHoiDongThi.ValueMember = "ExaminationCouncil_PositionID";

            // cbx Dia Diem
            cbxDiaDiem.DataSource = db.LOCATIONS
                                    .Where(p => p.ContestID == kithi.ContestID)
                                    .Where(p => p.Status == 1)
                                    .ToList();
            cbxDiaDiem.DisplayMember = "LocationName";
            cbxDiaDiem.ValueMember = "LocationID";
        }
        private void LoadDgvHoiDongThi()
        {
            int i = 1;
            dgvHoiDongThi.DataSource = db.EXAMINATIONCOUNCIL_STAFFS.ToList()
                                       .Where(p => p.ContestID == kithi.ContestID)
                                       .Where(p => p.Status == 1)
                                       .OrderBy(p => p.ExaminationCouncil_PositionID)
                                       .Select(p => new
                                       {
                                           ID = p.ExaminationCouncil_StaffID,
                                           STT = i++,
                                           HoTen = db.STAFFS.Where(cb => cb.StaffID == p.StaffID).FirstOrDefault().FullName,
                                           ChucVu = db.EXAMINATIONCOUNCIL_POSITIONS.Where(cv => cv.ExaminationCouncil_PositionID == p.ExaminationCouncil_PositionID).FirstOrDefault().ExaminationCouncil_PositionName,
                                           DiaDiem = db.LOCATIONS.Where(dd => dd.LocationID == p.LocationID).FirstOrDefault().LocationName,
                                           TaiKhoan = p.UserName
                                       })
                                       .ToList();

            // chỉnh index
            try
            {
                indexHoiDongThi = indexHoiDongThi1;
                dgvHoiDongThi.Rows[indexHoiDongThi].Cells["STTHoiDongThi"].Selected = true;
                dgvHoiDongThi.Select();
            }
            catch { }
        }
        private void ucThemPhanCongHoiDongThi_Load(object sender, EventArgs e)
        {

            int cnt = db.LOCATIONS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList().Count;
            if (cnt == 0)
            {
                MessageBox.Show("Kì thi chưa có địa điểm nào",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.Visible = false;
            }

            InitControlHoiDongThi();
            LoadDgvHoiDongThi();
            groupThongTinHoiDongThi.Enabled = false;

            // load txtTaiKhoan
            try
            {
                int id = (int)cbxCanBoHoiDongThi.SelectedValue;
                STAFF cb = db.STAFFS.Where(p => p.StaffID == id).FirstOrDefault();
                txtTaiKhoanHoiDongThi.Text = cb.Username + kithi.ContestID.ToString();
            }
            catch
            {

            }

             // kiem tra xem ki thi dc phe duyet chua
             if (kithi.Status > 0)
            {
                btnThemPhanCongHoiDongThi.Visible = false;
                btnXoaPhanCongHoiDongThi.Visible = false;
            }
        }
        #endregion

        #region Hàm chức năng

        private void ClearControlHoiDongThi()
        {
            //txtTaiKhoanHoiDongThi.Text = "";
            try
            {
                cbxCanBoHoiDongThi.SelectedIndex = 0;
                cbxChucVuHoiDongThi.SelectedIndex = 0;
                cbxDiaDiem.SelectedIndex = 0;
            }
            catch
            {

            }
        }
        private void UpdateDetailHoiDongThi()
        {
            if (dgvHoiDongThi.SelectedRows.Count < 1) return;
            try
            {
                EXAMINATIONCOUNCIL_STAFFS pc = GetPhanCongHoiDongThiWithID();
                txtTaiKhoanHoiDongThi.Text = pc.UserName;
                cbxCanBoHoiDongThi.SelectedValue = pc.StaffID;
                cbxChucVuHoiDongThi.SelectedValue = pc.ExaminationCouncil_PositionID;
                cbxDiaDiem.SelectedValue = pc.LocationID;
            }
            catch { }
        }
        private bool CheckHoiDongThi()
        {
            // xem can bo nay da dc them vao chua
            int cnt = db.EXAMINATIONCOUNCIL_STAFFS
                      .Where(p => p.ContestID == kithi.ContestID)
                      .Where(p => p.Status == 1)
                      .Where(p => p.StaffID == (int)cbxCanBoHoiDongThi.SelectedValue)
                      .ToList()
                      .Count;
            if (cnt > 0)
            {
                MessageBox.Show("Cán bộ " + db.STAFFS.Where(p => p.StaffID == (int)cbxCanBoHoiDongThi.SelectedValue).FirstOrDefault().FullName + " đã được phân công",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // kiểm tra xem địa điểm đó đã có điểm trưởng chưa
            int dem = db.EXAMINATIONCOUNCIL_STAFFS
                      .Where(p => p.ContestID == kithi.ContestID)
                      .Where(p => p.Status == 1)
                      .Where(p => p.LocationID == (int)cbxDiaDiem.SelectedValue)
                      .Where(p => p.ExaminationCouncil_PositionID == (int)cbxChucVuHoiDongThi.SelectedValue)
                      .Where(p => db.EXAMINATIONCOUNCIL_POSITIONS.Where(cv => cv.ExaminationCouncil_PositionID == p.ExaminationCouncil_PositionID).FirstOrDefault().ExaminationCouncil_PositionCode == "DT")
                      .ToList()
                      .Count;
            if (dem > 0)
            {
                MessageBox.Show("Địa điểm " + db.LOCATIONS.Where(p => p.LocationID == (int)cbxDiaDiem.SelectedValue).FirstOrDefault().LocationName + " đã được phân công điểm trưởng",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private EXAMINATIONCOUNCIL_STAFFS GetPhanCongHoiDongThiWithID()
        {
            try
            {
                int id = (int)dgvHoiDongThi.SelectedRows[0].Cells["IDHoiDongThi"].Value;
                EXAMINATIONCOUNCIL_STAFFS ans = db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.ExaminationCouncil_StaffID == id).First();
                return ans;
            }
            catch
            {
                return new EXAMINATIONCOUNCIL_STAFFS();
            }
        }

        private EXAMINATIONCOUNCIL_STAFFS GetPhanCongHoiDongThiWithThongTin()
        {
            EXAMINATIONCOUNCIL_STAFFS ans = new EXAMINATIONCOUNCIL_STAFFS();
            ans.ContestID = kithi.ContestID;
            ans.Status = 1;
            ans.StaffID = (int)cbxCanBoHoiDongThi.SelectedValue;
            ans.ExaminationCouncil_PositionID = (int)cbxChucVuHoiDongThi.SelectedValue;
            ans.LocationID = (int)cbxDiaDiem.SelectedValue;
            ans.UserName = txtTaiKhoanHoiDongThi.Text;
            ans.Password = db.STAFFS.Where(p => p.StaffID == ans.StaffID).FirstOrDefault().Password;

            return ans;
        }


        #endregion

        #region Sự kiện ngầm
        private void cbxDiaDiem_EnabledChanged(object sender, EventArgs e)
        {
            // cbx Dia Diem
            if (cbxDiaDiem.Enabled == false) return;
            cbxDiaDiem.DataSource = db.LOCATIONS
                                    .Where(p => p.ContestID == kithi.ContestID)
                                    .Where(p => p.Status == 1)
                                    .ToList();
            cbxDiaDiem.DisplayMember = "LocationName";
            cbxDiaDiem.ValueMember = "LocationID";
        }
        private void cbxCanBoHoiDongThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)cbxCanBoHoiDongThi.SelectedValue;
                STAFF cb = db.STAFFS.Where(p => p.StaffID == id).FirstOrDefault();
                txtTaiKhoanHoiDongThi.Text = cb.Username;
            }
            catch
            {

            }
        }

        private void dgvHoiDongThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoiDongThi.SelectedRows.Count < 1) return;
            try
            {
                UpdateDetailHoiDongThi();
                indexHoiDongThi1 = indexHoiDongThi;
                indexHoiDongThi = dgvHoiDongThi.SelectedRows[0].Index;
            }
            catch { }
        }

        #endregion

        #region sự kiện
        private void btnThemPhanCongHoiDongThi_Click(object sender, EventArgs e)
        {
            if (btnThemPhanCongHoiDongThi.Text == "Thêm phân công")
            {
                btnThemPhanCongHoiDongThi.Text = "Lưu";
                btnXoaPhanCongHoiDongThi.Text = "Hủy";

                dgvHoiDongThi.Enabled = false;
                groupThongTinHoiDongThi.Enabled = true;
                ClearControlHoiDongThi();

                return;
            }

            if (btnThemPhanCongHoiDongThi.Text == "Lưu")
            {
                if (CheckHoiDongThi())
                {
                    btnThemPhanCongHoiDongThi.Text = "Thêm phân công";
                    btnXoaPhanCongHoiDongThi.Text = "Xóa phân công";

                    dgvHoiDongThi.Enabled = true;
                    groupThongTinHoiDongThi.Enabled = false;

                    EXAMINATIONCOUNCIL_STAFFS tg = GetPhanCongHoiDongThiWithThongTin();
                    db.EXAMINATIONCOUNCIL_STAFFS.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin phân công hội đồng thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvHoiDongThi();
                }
                return;
            }
        }

        private void btnXoaPhanCongHoiDongThi_Click(object sender, EventArgs e)
        {
            if (btnXoaPhanCongHoiDongThi.Text == "Xóa phân công")
            {
                EXAMINATIONCOUNCIL_STAFFS tg = GetPhanCongHoiDongThiWithID();
                if (tg.ExaminationCouncil_StaffID == 0)
                {
                    MessageBox.Show("Chưa có phân công nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa phân công này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                tg.Status = 0;
                db.SaveChanges();

                MessageBox.Show("Xóa thông tin phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvHoiDongThi();

                return;
            }

            if (btnXoaPhanCongHoiDongThi.Text == "Hủy")
            {
                btnThemPhanCongHoiDongThi.Text = "Thêm phân công";
                btnXoaPhanCongHoiDongThi.Text = "Xóa phân công";

                dgvHoiDongThi.Enabled = true;
                groupThongTinHoiDongThi.Enabled = false;

                UpdateDetailHoiDongThi();
                return;
            }
        }

        #endregion
    }
}
