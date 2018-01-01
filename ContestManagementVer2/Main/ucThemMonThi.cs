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
    public partial class ucThemMonThi : UserControl
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi;
        private int indexMonThi = 0, indexMonThi1 = 0;

        #region Khởi tạo
        public ucThemMonThi(CONTEST ct)
        {
            InitializeComponent();
            kithi = ct;
            DAO.DBService.Reload();
        }

        #endregion

        #region LoadForm

        private void InitControlMonThi()
        {
            //  cbxMonThi
            cbxMonThi.DataSource = db.SUBJECTS.Where(p => p.Status == 1).ToList();
            cbxMonThi.DisplayMember = "SubjectName";
            cbxMonThi.ValueMember = "SubjectID";

            // cbxHinhThucThi
            cbxHinhThucThi.DataSource = db.CONTEST_TYPES.Where(p => p.Status == 1).ToList();
            cbxHinhThucThi.DisplayMember = "ContestTypeName";
            cbxHinhThucThi.ValueMember = "ContestTypeID";
        }
        private void LoadDgvMonThi()
        {
            int i = 1;
            dgvMonThi.DataSource = db.SCHEDULES.ToList()
                                   .Where(p => p.ContestID == kithi.ContestID)
                                   .Where(p => p.Status == 1)
                                   .Select(p => new
                                   {
                                       ID = p.ScheduleID,
                                       STT = i++,
                                       MonThi = db.SUBJECTS.Where(mh => mh.SubjectID == p.SubjectID).FirstOrDefault().SubjectName,
                                       ThoiGianThi = (p.TimeOfTest / 60).ToString() + " Phút",
                                       ThoiGianNopBai = (p.TimeToSubmit / 60).ToString() + " Phút",
                                       HinhThucThi = db.CONTEST_TYPES.Where(ht => ht.ContestTypeID == p.ContestTypeID).FirstOrDefault().ContestTypeName,
                                       LePhiThi = p.Fee

                                   })
                                   .ToList();

            // chỉnh lại index
            try
            {
                indexMonThi = indexMonThi1;
                dgvMonThi.Rows[indexMonThi].Cells["STT"].Selected = true;
                dgvMonThi.Select();
            }
            catch { }
        }

        private void ucThemMonThi_Load(object sender, EventArgs e)
        {
            InitControlMonThi();
            LoadDgvMonThi();
            groupThongTinMonThi.Enabled = false;

            if (kithi.Status > 0) {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
        }
        #endregion

        #region Hàm chức năng

        private void ClearControlMonThi()
        {
            cbxMonThi.SelectedIndex = 0;
            cbxHinhThucThi.SelectedIndex = 0;
            txtTimeOfTest.Value = 0;
            txtTimeToSubmit.Value = 0;
        }
        private void UpdateDetailMonThi()
        {
            if (dgvMonThi.SelectedRows.Count <= 0) return;
            try
            {
                SCHEDULE tg = GetMonThiWithID();
                cbxMonThi.SelectedValue = tg.SubjectID;
                cbxHinhThucThi.SelectedValue = tg.ContestTypeID;
                txtTimeOfTest.Value = tg.TimeOfTest / 60;
                txtTimeToSubmit.Value = tg.TimeToSubmit / 60;
                txtLePhiThi.Text = tg.Fee.ToString();
            }
            catch
            {

            }
        }
        private bool CheckMonThi()
        {

            if (txtTimeOfTest.Text == "")
            {
                MessageBox.Show("Thời gian thi không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTimeToSubmit.Text == "")
            {
                MessageBox.Show("Thời gian nộp bài không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // kiểm tra ràng buộc 1 kì thi k có 2 môn trùng tên
            SCHEDULE tg = GetMonThiWithThongTin();
            SCHEDULE z = GetMonThiWithID();

            int cnt = db.SCHEDULES
                        .Where(p=>p.ScheduleID != z.ScheduleID)
                        .Where(p => p.ContestID == kithi.ContestID)
                        .Where(p => p.SubjectID == tg.SubjectID)
                        .Where(p => p.Status == 1)
                        .ToList().Count;
            if (cnt > 0)
            {
                MessageBox.Show("Môn thi này đã được thêm trong kì thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (tg.TimeOfTest < 300)
            {
                MessageBox.Show("Thời gian thi tối thiểu của mỗi môn là 5 phút", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (tg.TimeToSubmit >= tg.TimeOfTest * 3 / 2)
            {
                MessageBox.Show("Thời gian nộp bài sớm nhất có thể là 2/3 thời gian", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (tg.TimeToSubmit > tg.TimeOfTest)
            {
                MessageBox.Show("Thời gian tối thiểu để nộp bài không được lớn hơn thời gian thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool ok = true;
            try
            {
                int z1 = Int32.Parse(txtLePhiThi.Text);
                ok = true;
            }
            catch { ok = false; }
            if (!ok)
            {
                MessageBox.Show("Lệ phí thi phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private SCHEDULE GetMonThiWithID()
        {
            try
            {
                int ID = (int)dgvMonThi.SelectedRows[0].Cells["IDMonThi"].Value;
                return db.SCHEDULES.Where(p => p.ScheduleID == ID).First();
            }
            catch
            {
                return new SCHEDULE();
            }
        }

        private SCHEDULE GetMonThiWithThongTin()
        {
            SCHEDULE ans = new SCHEDULE();
            ans.ContestID = kithi.ContestID;
            ans.SubjectID = (int)cbxMonThi.SelectedValue;
            ans.ContestTypeID = (int)cbxHinhThucThi.SelectedValue;
            ans.TimeOfTest = Int32.Parse(txtTimeOfTest.Text) * 60;
            ans.TimeToSubmit = Int32.Parse(txtTimeToSubmit.Text) * 60;
            try
            {
                ans.Fee = Int32.Parse(txtLePhiThi.Text);
            }
            catch
            {

            }
            ans.Status = 1;

            return ans;
        }

        
        #endregion

        #region Sự kiện ngầm
        private void dgvMonThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonThi.SelectedRows.Count <= 0) return;
            try
            {
                UpdateDetailMonThi();
                indexMonThi1 = indexMonThi;
                indexMonThi = dgvMonThi.SelectedRows[0].Index;
            }
            catch
            {

            }
        }
        #endregion

        #region Sự kiện

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnSua.Enabled = false;

                dgvMonThi.Enabled = false;
                groupThongTinMonThi.Enabled = true;

                ClearControlMonThi();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (CheckMonThi())
                {
                    btnThem.Text = "Thêm";
                    btnXoa.Text = "Xóa";
                    btnSua.Enabled = true;

                    dgvMonThi.Enabled = true;
                    groupThongTinMonThi.Enabled = false;

                    SCHEDULE tg = GetMonThiWithThongTin();
                    db.SCHEDULES.Add(tg);
                    db.SaveChanges();


                    MessageBox.Show("Thêm thông tin môn thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvMonThi();
                }
                return;
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SCHEDULE tg = GetMonThiWithID();

            if (tg.ScheduleID == 0)
            {
                MessageBox.Show("Chưa có môn thi nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (btnSua.Text == "Sửa")
            {
                btnThem.Enabled = false;
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";

                dgvMonThi.Enabled = false;
                groupThongTinMonThi.Enabled = true;

                return;
            }

            if (btnSua.Text == "Lưu")
            {

                if (CheckMonThi())
                {
                    btnThem.Enabled = true;
                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";

                    dgvMonThi.Enabled = true;
                    groupThongTinMonThi.Enabled = false;

                    SCHEDULE sua = GetMonThiWithThongTin();
                    tg.SubjectID = sua.SubjectID;
                    tg.TimeOfTest = sua.TimeOfTest;
                    tg.TimeToSubmit = sua.TimeToSubmit;
                    tg.ContestTypeID = sua.ContestTypeID;
                    tg.Fee = sua.Fee;

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Sửa thông tin môn thi thành công",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thông tin môn thi thất bại\n" + ex.Message,
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }

                    LoadDgvMonThi();

                }

                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Xóa")
            {
                SCHEDULE tg = GetMonThiWithID();
                if (tg.ScheduleID == 0)
                {
                    MessageBox.Show("Chưa có môn thi nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Đồng chí có chắc chắn Xóa môn thi " + db.SUBJECTS.Where(p => p.SubjectID == tg.SubjectID).FirstOrDefault().SubjectName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                tg.Status = 0;

                db.SaveChanges();


                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvMonThi();

                return;
            }

            if (btnXoa.Text == "Hủy")
            {
                btnThem.Text = "Thêm";
                btnXoa.Text = "Xóa";
                btnSua.Text = "Sửa";

                btnThem.Enabled = true;
                btnSua.Enabled = true;

                dgvMonThi.Enabled = true;
                groupThongTinMonThi.Enabled = false;

                UpdateDetailMonThi();
                return;
            }
        }

        #endregion
    }
}
