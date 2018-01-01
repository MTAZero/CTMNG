using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON_ExamManagement.UC.UI;
using EXON_EM.Data.Model;
using EXON_EM.Data.Service;

namespace EXON_ExamManagement.UC.LapKeHoachKiThi
{
    public partial class ucThemMonThi : UserControl
    {
        private List<UserControl> listUc = new List<UserControl>();
        public CONTEST kithi { get; set; }
        private int indexMonThi = 0, indexMonThi1 = 0;

        #region constructor
        public ucThemMonThi()
        {
            InitializeComponent();
            panelStatus.Controls.Clear();

            kithi = new CONTEST();
            listUc = ucLapKeHoachThiHelper.getListUserControl(2);
            panelStatus.Controls.AddRange(listUc.ToArray());
        }
        #endregion

        #region Load Form
        private void InitControlMonThi()
        {
            //  cbxMonThi
            cbxMonThi.DataSource = new Subject_Service().getAll().Where(p => p.Status == 1).ToList();
            cbxMonThi.DisplayMember = "SubjectName";
            cbxMonThi.ValueMember = "SubjectID";

            // cbxHinhThucThi
            cbxHinhThucThi.DataSource = new ContestType_Service().getAll().Where(p => p.Status == 1).ToList();
            cbxHinhThucThi.DisplayMember = "ContestTypeName";
            cbxHinhThucThi.ValueMember = "ContestTypeID";
        }
        private void LoadDgvMonThi()
        {
            if (kithi.ContestID == 0) return;
            int i = 1;
            dgvMonThi.DataSource = new Schedule_Service().getAll().ToList()
                                   .Where(p => p.ContestID == kithi.ContestID)
                                   .Where(p => p.Status == 1)
                                   .Select(p => new
                                   {
                                       ID = p.ScheduleID,
                                       STT = i++,
                                       MonThi = new Subject_Service().getAll().Where(mh => mh.SubjectID == p.SubjectID).FirstOrDefault().SubjectName,
                                       ThoiGianThi = (p.TimeOfTest / 60).ToString() + " Phút",
                                       ThoiGianNopBai = (p.TimeToSubmit / 60).ToString() + " Phút",
                                       HinhThucThi = new ContestType_Service().getAll().Where(ht => ht.ContestTypeID == p.ContestTypeID).FirstOrDefault().ContestTypeName,
                                       LePhiThi = p.Fee

                                   })
                                   .ToList();

            // chỉnh lại index
            try
            {
                indexMonThi = indexMonThi1;
                dgvMonThi.Rows[indexMonThi].Cells["STTMonThi"].Selected = true;
                dgvMonThi.Select();
            }
            catch { }
        }
        private void ucThemMonThi_Load(object sender, EventArgs e)
        {
            InitControlMonThi();
            LoadDgvMonThi();
            groupThongTinMonThi.Enabled = false;
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

            int cnt = new Schedule_Service().getAll()
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
                int z = Int32.Parse(txtLePhiThi.Text);
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
                return new Schedule_Service().getAll().Where(p => p.ScheduleID == ID).First();
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

        #region sự kiện ngầm
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

        #region sự kiện
        private void btnThemMonThi_Click(object sender, EventArgs e)
        {
            if (btnThemMonThi.Text == "Thêm môn thi")
            {
                btnThemMonThi.Text = "Lưu";
                btnXoaMonThi.Text = "Hủy";

                dgvMonThi.Enabled = false;
                groupThongTinMonThi.Enabled = true;

                ClearControlMonThi();

                return;
            }

            if (btnThemMonThi.Text == "Lưu")
            {
                if (CheckMonThi())
                {
                    btnThemMonThi.Text = "Thêm môn thi";
                    btnXoaMonThi.Text = "Xóa môn thi";

                    dgvMonThi.Enabled = true;
                    groupThongTinMonThi.Enabled = false;

                    SCHEDULE tg = GetMonThiWithThongTin();
                    new Schedule_Service().Add(tg);

                    MessageBox.Show("Thêm thông tin môn thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvMonThi();
                }
                return;
            }
        }

        private void btnXoaMonThi_Click(object sender, EventArgs e)
        {
            if (btnXoaMonThi.Text == "Xóa môn thi")
            {
                SCHEDULE tg = GetMonThiWithID();
                if (tg.ScheduleID == 0)
                {
                    MessageBox.Show("Chưa có môn thi nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Đồng chí có chắc chắn xóa môn thi " + new Subject_Service().getAll().Where(p => p.SubjectID == tg.SubjectID).FirstOrDefault().SubjectName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                tg.Status = 0;
                new Schedule_Service().Update(tg);


                MessageBox.Show("Xóa môn thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvMonThi();

                return;
            }

            if (btnXoaMonThi.Text == "Hủy")
            {
                btnThemMonThi.Text = "Thêm môn thi";
                btnXoaMonThi.Text = "Xóa môn thi";

                dgvMonThi.Enabled = true;
                groupThongTinMonThi.Enabled = false;

                UpdateDetailMonThi();
                return;
            }
        }
        #endregion
    }
}
