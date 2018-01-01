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
using ContestManagementVer2.DAO;

namespace ContestManagementVer2.Main
{
    public partial class ucThemCaThi : UserControl
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();
        private int indexCaThi = 0, indexCaThi1 = 0;

        #region Hàm khởi tạo
        public ucThemCaThi(CONTEST _ct)
        {
            InitializeComponent();
            kithi = _ct;
            DAO.DBService.Reload();
        }

        #endregion

        #region LoadForm

        private void InitControlCaThi()
        {
            cbxLoaiCaThi.SelectedIndex = 0;
        }
        private void LoadDgvCaThi()
        {
            int i = 1;
            dgvCaThi.DataSource = db.SHIFTS.ToList()
                                   .Where(p => p.ContestID == kithi.ContestID)
                                   .Where(p => p.Status > 0)
                                   .OrderBy(p => p.ShiftDate)
                                   .Select(p => new
                                   {
                                       ID = p.ShiftID,
                                       STT = i++,
                                       TenCaThi = p.ShiftName,
                                       NgayThi = DAO.Helper.ConvertUnixToDateTime(p.ShiftDate).ToString("dd/MM/yyyy"),
                                       ThoiGianBatDau = DAO.Helper.ConvertUnixToDateTime(p.StartTime).ToString("HH:mm"),
                                       ThoiGianKetThuc = DAO.Helper.ConvertUnixToDateTime(p.EndTime).ToString("HH:mm")
                                   })
                                   .ToList();

            // chỉnh lại index
            try
            {
                indexCaThi = indexCaThi1;
                dgvCaThi.Rows[indexCaThi].Cells["STTCaThi"].Selected = true;
                dgvCaThi.Select();
            }
            catch { }
        }

        private void ucThemCaThi_Load(object sender, EventArgs e)
        {
            InitControlCaThi();
            LoadDgvCaThi();
            groupThongTinCaThi.Enabled = false;

            if (kithi.Status > 0)
            {
                btnThemCaThi.Visible = false;
                btnSuaCaThi.Visible = false;
                btnXoaCaThi.Visible = false;
            }
        }
        #endregion

        #region Hàm chức năng

        private void ClearControlCaThi()
        {
            txtShiftName.Text = "";
            cbxLoaiCaThi.SelectedIndex = 0;
            dateBatDau.Value = new DateTime(1970, 1, 1, 0, 0, 0);
            dateKetThuc.Value = new DateTime(1970, 1, 1, 0, 0, 0);
        }
        private void UpdateDetailCaThi()
        {
            if (dgvCaThi.SelectedRows.Count <= 0) return;
            try
            {
                SHIFT tg = GetCaThiWithID();

                txtShiftName.Text = tg.ShiftName;
                cbxLoaiCaThi.SelectedIndex = tg.Status - 1;
                dateBatDau.Value = Helper.ConvertUnixToDateTime(tg.StartTime);
                dateKetThuc.Value = Helper.ConvertUnixToDateTime(tg.EndTime);

            }
            catch
            {

            }
        }
        private bool CheckCaThi()
        {

            if (txtShiftName.Text == "")
            {
                MessageBox.Show("Tên ca thi không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateBatDau.Value > dateKetThuc.Value)
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private SHIFT GetCaThiWithID()
        {
            try
            {
                int ID = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                return db.SHIFTS.Where(p => p.ShiftID == ID).First();
            }
            catch
            {
                return new SHIFT();
            }
        }

       

        private SHIFT GetCaThiWithThongTin()
        {
            SHIFT ans = new SHIFT();
            ans.ContestID = kithi.ContestID;
            ans.StartTime = Helper.ConvertDateTimeToUnix(dateBatDau.Value);
            ans.EndTime = Helper.ConvertDateTimeToUnix(dateKetThuc.Value);
            ans.Status = cbxLoaiCaThi.SelectedIndex + 1;
            ans.ShiftName = txtShiftName.Text;

            return ans;
        }

        #endregion

        #region Sự kiện ngầm

        private void dgvCaThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCaThi.SelectedRows.Count <= 0) return;
            try
            {
                UpdateDetailCaThi();
                indexCaThi1 = indexCaThi;
                indexCaThi = dgvCaThi.SelectedRows[0].Index;
            }
            catch
            {

            }
        }

        #endregion

        #region Sự kiện

        private void btnThemCaThi_Click(object sender, EventArgs e)
        {
            if (btnThemCaThi.Text == "Thêm")
            {
                btnThemCaThi.Text = "Lưu";
                btnXoaCaThi.Text = "Hủy";
                btnSuaCaThi.Enabled = false;

                dgvCaThi.Enabled = false;
                groupThongTinCaThi.Enabled = true;

                ClearControlCaThi();

                return;
            }

            if (btnThemCaThi.Text == "Lưu")
            {
                if (CheckCaThi())
                {
                    btnThemCaThi.Text = "Thêm";
                    btnXoaCaThi.Text = "Xóa";
                    btnSuaCaThi.Enabled = true;

                    dgvCaThi.Enabled = true;
                    groupThongTinCaThi.Enabled = false;

                    SHIFT tg = GetCaThiWithThongTin();

                    DateTime date = Helper.ConvertUnixToDateTime((int)kithi.BeginDate);
                    DateTime shiftTime = Helper.ConvertUnixToDateTime((int)tg.StartTime);
                    DateTime shiftDate = new DateTime(date.Year, date.Month, date.Day, shiftTime.Hour, shiftTime.Minute, shiftTime.Second);

                    int dem = 0;
                    while (true)
                    {

                        SHIFT tgz = new SHIFT();
                        tgz.ShiftName = tg.ShiftName + " Ngày " + shiftDate.ToString("dd/MM/yyyy");
                        tgz.ShiftDate = Helper.ConvertDateTimeToUnix(shiftDate);
                        tgz.StartTime = tg.StartTime;
                        tgz.EndTime = tg.EndTime;
                        tgz.Status = tg.Status;
                        tgz.ContestID = tg.ContestID;
                        if (shiftDate >= Helper.ConvertUnixToDateTime((int)kithi.BeginDate))
                        {
                            db.SHIFTS.Add(tgz);
                            dem++;
                        }
                        shiftDate = shiftDate.AddDays(1);
                        if (shiftDate > Helper.ConvertUnixToDateTime((int)kithi.EndDate)) break;
                    }

                    db.SaveChanges();

                    if (dem > 0)
                        MessageBox.Show("Thêm thông tin ca thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Không có ca thi nào được thêm trong khoàng thời gian này\nThời gian ca thi bắt đầu phải lớn hơn thời gian bắt đầu của kì thi",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    LoadDgvCaThi();
                }
                return;
            }
        }

        private void btnSuaCaThi_Click(object sender, EventArgs e)
        {
            SHIFT tg = GetCaThiWithID();

            if (tg.ShiftID == 0)
            {
                MessageBox.Show("Chưa có ca thi nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (btnSuaCaThi.Text == "Sửa")
            {
                btnSuaCaThi.Text = "Lưu";
                btnThemCaThi.Enabled = false;
                btnXoaCaThi.Text = "Hủy";

                groupThongTinCaThi.Enabled = true;
                dgvCaThi.Enabled = false;

                return;
            }

            if (btnSuaCaThi.Text == "Lưu")
            {

                if (CheckCaThi())
                {
                    btnSuaCaThi.Text = "Sửa";
                    btnXoaCaThi.Text = "Xóa";
                    btnThemCaThi.Enabled = true;

                    groupThongTinCaThi.Enabled = false;
                    dgvCaThi.Enabled = true;

                    SHIFT tgz = GetCaThiWithThongTin();

                    // sửa thông tin của ca thi đó
                    tg.ShiftName = tgz.ShiftName;
                    tg.ContestID = tgz.ContestID;
                    tg.StartTime = tgz.StartTime;
                    tg.EndTime = tgz.EndTime;
                    tg.Status = tgz.Status;

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Sửa thông tin ca thi thành công",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thông tin ca thi thất bại\n" + ex.Message,
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
           
                    LoadDgvCaThi();


                    return;
                }

                return;
            }
        }

        private void btnXoaCaThi_Click(object sender, EventArgs e)
        {
            if (btnXoaCaThi.Text == "Xóa")
            {
                SHIFT tg = GetCaThiWithID();
                if (tg.ShiftID == 0)
                {
                    MessageBox.Show("Chưa có ca thi nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Đồng chí có chắc chắn xóa ca thi " + tg.ShiftName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                tg.Status = 0;
                db.SaveChanges();
                MessageBox.Show("Xóa ca thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvCaThi();

                return;
            }

            if (btnXoaCaThi.Text == "Hủy")
            {
                btnThemCaThi.Text = "Thêm";
                btnXoaCaThi.Text = "Xóa";
                btnSuaCaThi.Text = "Sửa";

                btnThemCaThi.Enabled = true;
                btnSuaCaThi.Enabled = true;

                dgvCaThi.Enabled = true;
                groupThongTinCaThi.Enabled = false;

                UpdateDetailCaThi();
                return;
            }
        }

        #endregion

    }
}
