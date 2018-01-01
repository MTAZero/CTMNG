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
    public partial class ucThemDiaDiemPhongThi : UserControl
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region Hàm khởi tạo
        public ucThemDiaDiemPhongThi(CONTEST _ct)
        {
            InitializeComponent();
            kithi = _ct;
            DAO.DBService.Reload();
        }


        #endregion

        #region Form chính
        private void ucThemDiaDiemPhongThi_Load(object sender, EventArgs e)
        {
            LoadDiaDiemThi();
            
        }
        #endregion

        #region địa điểm - phòng thi
        private int indexDiaDiem = 0, indexDiaDiem1 = 0;
        private int indexPhongThi = 0, indexPhongThi1 = 0;

        #region Load
        private void LoadDgvPhongThi()
        {
            LOCATION lc = GetDiaDiemThiWithID();
            if (lc.ContestID == 0) return;

            int i = 1;
            dgvPhongThi.DataSource = db.ROOMTESTS.ToList()
                                        .Where(p => p.LocationID == lc.LocationID)
                                        .Where(p => p.Status == 1)
                                        .Select(p => new
                                        {
                                            ID = p.RoomTestID,
                                            STT = i++,
                                            TenPhongThi = p.RoomTestName,
                                            SoCho = p.MaxSeatMount,
                                            SoGiamThi = p.MaxSupervisor
                                        })
                                        .ToList();
            // chỉnh lại index
            try
            {
                indexPhongThi = indexPhongThi1;
                dgvPhongThi.Rows[indexPhongThi].Cells["STT"].Selected = true;
                dgvPhongThi.Select();
            }
            catch
            {

            }
        }
        private void LoadDgvDiaDiemThi()
        {
            int i = 1;
            dgvDiaDiemThi.DataSource = db.LOCATIONS
                                       .ToList()
                                       .Where(p => p.ContestID == kithi.ContestID)
                                       .Where(p => p.Status == 1)
                                       .Select(p => new
                                       {
                                           ID = p.LocationID,
                                           STT = i++,
                                           TenDiaDiemThi = p.LocationName
                                       })
                                       .ToList();

            // chỉnh lại index
            try
            {
                indexDiaDiem = indexDiaDiem1;
                dgvDiaDiemThi.Rows[indexDiaDiem].Cells["STTDiaDiemThi"].Selected = true;
                dgvDiaDiemThi.Select();
            }
            catch
            {

            }
        }

        private void LoadDiaDiemThi()
        {
            LoadDgvDiaDiemThi();
            groupThongTinDiaDiemThi.Enabled = false;
            groupThongTinPhongThi.Enabled = false;

            if (kithi.Status > 0)
            {
                btnThemDiaDiemThi.Visible = false;
                btnSuaDiaDiemThi.Visible = false;
                btnXoaDiaDiemThi.Visible = false;
                btnThemPhongThi.Visible = false;
                btnSuaPhongThi.Visible = false;
                btnXoaPhongThi.Visible = false;
            }
        }
        #endregion

        #region Hàm chức năng Dia Diem Thi
        private bool CheckDiaDiemThi()
        {
            return true;
        }

        private void ClearControlDiaDiemThi()
        {
            txtTenDiaDiemThi.Text = "";
        }
        private void UpdateDetailDiaDiemThi()
        {
            try
            {
                LOCATION lc = GetDiaDiemThiWithID();
                txtTenDiaDiemThi.Text = lc.LocationName;
            }
            catch
            {

            }
        }

        private LOCATION GetDiaDiemThiWithID()
        {
            try
            {
                int id = (int)dgvDiaDiemThi.SelectedRows[0].Cells["IDDiaDiemThi"].Value;
                return db.LOCATIONS.Where(p => p.LocationID == id).First();
            }
            catch
            {
                return new LOCATION();
            }
        }

        private LOCATION GetDiaDiemThiWithThongTin()
        {
            LOCATION ans = new LOCATION();
            ans.ContestID = kithi.ContestID;
            ans.LocationName = txtTenDiaDiemThi.Text;
            ans.Status = 1;
            return ans;
        }
        #endregion

        #region Hàm chức năng phòng thi
        private void ClearControlPhongThi()
        {
            txtTenPhongThi.Text = "";
            txtSoCho.Value = 1;
            txtSoGiamThi.Value = 1;
        }
        private void UpdateDetailPhongThi()
        {
            try
            {
                ROOMTEST rt = GetPhongThiWithID();
                txtTenPhongThi.Text = rt.RoomTestName;
                txtSoCho.Value = rt.MaxSeatMount;
                txtSoGiamThi.Value = (decimal)rt.MaxSupervisor;
            }
            catch
            {

            }
        }

        private bool CheckPhongThi()
        {
            int num = (int)txtSoCho.Value;
            if (num * 9 / 10 < 1)
            {
                MessageBox.Show("Không đủ máy dự phòng để sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private ROOMTEST GetPhongThiWithID()
        {
            try
            {
                int id = (int)dgvPhongThi.SelectedRows[0].Cells["ID"].Value;
                return db.ROOMTESTS.Where(p => p.RoomTestID == id).First();
            }
            catch
            {
                return new ROOMTEST();
            }
        }

        private ROOMTEST GetPhongThiWithThongTin()
        {
            LOCATION lc = GetDiaDiemThiWithID();

            ROOMTEST ans = new ROOMTEST();
            ans.RoomTestName = txtTenPhongThi.Text;
            ans.MaxSeatMount = Int32.Parse(txtSoCho.Text);
            ans.MaxSupervisor = Int32.Parse(txtSoGiamThi.Text);
            ans.Status = 1;
            ans.LocationID = lc.LocationID;

            return ans;
        }
        #endregion

        #region sự kiện ngầm

        private void dgvDiaDiemThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDiaDiemThi.SelectedRows.Count < 1) return;
            try
            {
                UpdateDetailDiaDiemThi();
                indexDiaDiem1 = indexDiaDiem;
                indexDiaDiem = dgvDiaDiemThi.SelectedRows[0].Index;
                LoadDgvPhongThi();
            }
            catch
            {

            }
        }

        private void dgvPhongThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhongThi.SelectedRows.Count < 1) return;
            try
            {
                UpdateDetailPhongThi();
                indexPhongThi1 = indexPhongThi;
                indexPhongThi = dgvPhongThi.SelectedRows[0].Index;
            }
            catch
            {

            }
        }
        #endregion

        #region sự kiện
        private void btnThemDiaDiemThi_Click(object sender, EventArgs e)
        {
            if (btnThemDiaDiemThi.Text == "Thêm địa điểm")
            {
                btnThemDiaDiemThi.Text = "Lưu";
                btnXoaDiaDiemThi.Text = "Hủy";
                btnSuaDiaDiemThi.Enabled = false;

                dgvDiaDiemThi.Enabled = false;
                dgvPhongThi.Enabled = false;
                groupThongTinDiaDiemThi.Enabled = true;

                btnThemPhongThi.Enabled = false;
                btnXoaPhongThi.Enabled = false;
                btnSuaPhongThi.Enabled = false;

                ClearControlDiaDiemThi();
                return;
            }

            if (btnThemDiaDiemThi.Text == "Lưu")
            {
                if (CheckDiaDiemThi())
                {
                    btnThemDiaDiemThi.Text = "Thêm địa điểm";
                    btnXoaDiaDiemThi.Text = "Xóa địa điểm";
                    btnSuaDiaDiemThi.Enabled = true;

                    dgvDiaDiemThi.Enabled = true;
                    dgvPhongThi.Enabled = true;
                    groupThongTinDiaDiemThi.Enabled = false;

                    btnThemPhongThi.Enabled = true;
                    btnXoaPhongThi.Enabled = true;
                    btnSuaPhongThi.Enabled = true;

                    LOCATION lc = GetDiaDiemThiWithThongTin();
                    db.LOCATIONS.Add(lc);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin địa điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvDiaDiemThi();
                }
                return;
            }
        }

        private void btnSuaDiaDiemThi_Click(object sender, EventArgs e)
        {
            LOCATION tg = GetDiaDiemThiWithID();

            if (tg.LocationID == 0)
            {
                MessageBox.Show("chưa có địa điểm thi nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (btnSuaDiaDiemThi.Text == "Sửa địa điểm")
            {
                btnSuaDiaDiemThi.Text = "Lưu";
                btnXoaDiaDiemThi.Text = "Hủy";
                btnThemDiaDiemThi.Enabled = false;

                btnSuaPhongThi.Enabled = false;
                btnThemPhongThi.Enabled = false;
                btnXoaPhongThi.Enabled = false;

                dgvDiaDiemThi.Enabled = false;
                dgvPhongThi.Enabled = false;
                groupThongTinDiaDiemThi.Enabled = true;

                return;
            }

            if (btnSuaDiaDiemThi.Text == "Lưu")
            {

                if (CheckDiaDiemThi())
                {
                    btnSuaDiaDiemThi.Text = "Sửa địa điểm";
                    btnXoaDiaDiemThi.Text = "Xóa";
                    btnThemDiaDiemThi.Enabled = true;

                    btnSuaPhongThi.Enabled = true;
                    btnThemPhongThi.Enabled = true;
                    btnXoaPhongThi.Enabled = true;

                    dgvDiaDiemThi.Enabled = true;
                    dgvPhongThi.Enabled = true;
                    groupThongTinDiaDiemThi.Enabled = false;

                    LOCATION tgz = GetDiaDiemThiWithThongTin();
                    tg.LocationName = tgz.LocationName;

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Sửa thông tin địa điểm thành công",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thông tin địa điểm thi thất bại\n" + ex.Message,
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    LoadDgvDiaDiemThi();

                }

                return;
            }
        }

        private void btnXoaDiaDiemThi_Click(object sender, EventArgs e)
        {
            if (btnXoaDiaDiemThi.Text == "Xóa địa điểm")
            {
                LOCATION tg = GetDiaDiemThiWithID();
                if (tg.LocationID == 0)
                {
                    MessageBox.Show("Chưa có địa điểm nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa địa điểm " + tg.LocationName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                tg.Status = 0;

                // Xóa các phòng thi thuộc địa điểm đó
                var listRoomTest = db.ROOMTESTS.Where(p => p.LocationID == tg.LocationID).ToList();
                foreach (ROOMTEST pt in listRoomTest) pt.Status = 0;
                foreach (EXAMINATIONCOUNCIL_STAFFS zz in db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.LocationID == tg.LocationID).ToList())
                    zz.Status = 0;
                db.SaveChanges();

                MessageBox.Show("Xóa thông tin địa điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvDiaDiemThi();

                return;
            }

            if (btnXoaDiaDiemThi.Text == "Hủy")
            {
                btnThemDiaDiemThi.Text = "Thêm địa điểm";
                btnXoaDiaDiemThi.Text = "Xóa địa điểm";
                btnSuaDiaDiemThi.Text = "Sửa địa điểm";

                btnThemDiaDiemThi.Enabled = true;
                btnSuaDiaDiemThi.Enabled = true;

                dgvDiaDiemThi.Enabled = true;
                dgvPhongThi.Enabled = true;
                groupThongTinDiaDiemThi.Enabled = false;

                btnThemPhongThi.Enabled = true;
                btnXoaPhongThi.Enabled = true;
                btnSuaPhongThi.Enabled = true;

                UpdateDetailDiaDiemThi();

                return;
            }
        }

        #endregion

        #region sự kiện phòng thi
        private void btnThemPhongThi_Click(object sender, EventArgs e)
        {
            LOCATION lc = GetDiaDiemThiWithID();
            if (lc.LocationID == 0)
            {
                MessageBox.Show("Chưa có địa điểm nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnThemPhongThi.Text == "Thêm phòng thi")
            {
                btnThemPhongThi.Text = "Lưu";
                btnXoaPhongThi.Text = "Hủy";
                btnSuaPhongThi.Enabled = false;

                dgvDiaDiemThi.Enabled = false;
                dgvPhongThi.Enabled = false;

                btnThemDiaDiemThi.Enabled = false;
                btnXoaDiaDiemThi.Enabled = false;
                btnSuaDiaDiemThi.Enabled = false;
                groupThongTinPhongThi.Enabled = true;
                ClearControlPhongThi();

                return;
            }

            if (btnThemPhongThi.Text == "Lưu")
            {
                if (CheckPhongThi())
                {
                    btnXoaPhongThi.Text = "Xóa phòng thi";
                    btnThemPhongThi.Text = "Thêm phòng thi";
                    btnSuaPhongThi.Enabled = true;

                    dgvPhongThi.Enabled = true;
                    dgvDiaDiemThi.Enabled = true;

                    btnXoaDiaDiemThi.Enabled = true;
                    btnThemDiaDiemThi.Enabled = true;
                    btnSuaDiaDiemThi.Enabled = true;
                    groupThongTinPhongThi.Enabled = false;

                    ROOMTEST rt = GetPhongThiWithThongTin();
                    db.ROOMTESTS.Add(rt);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin phòng thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvPhongThi();
                }
                return;
            }
        }

        private void btnSuaPhongThi_Click(object sender, EventArgs e)
        {
            ROOMTEST tg = GetPhongThiWithID();

            if (tg.RoomTestID == 0)
            {
                MessageBox.Show("Chưa có phòng thi được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (btnSuaPhongThi.Text == "Sửa phòng thi")
            {
                btnSuaPhongThi.Text = "Lưu";
                btnXoaPhongThi.Text = "Hủy";
                btnThemPhongThi.Enabled = false;

                btnThemDiaDiemThi.Enabled = false;
                btnSuaDiaDiemThi.Enabled = false;
                btnXoaDiaDiemThi.Enabled = false;

                groupThongTinPhongThi.Enabled = true;
                dgvPhongThi.Enabled = false;
                dgvDiaDiemThi.Enabled = false;

                return;
            }

            if (btnSuaPhongThi.Text == "Lưu")
            {
                if (CheckPhongThi())
                {
                    btnSuaPhongThi.Text = "Sửa phòng thi";
                    btnXoaPhongThi.Text = "Hủy";
                    btnThemPhongThi.Enabled = true;

                    btnThemDiaDiemThi.Enabled = true;
                    btnSuaDiaDiemThi.Enabled = true;
                    btnXoaDiaDiemThi.Enabled = true;

                    groupThongTinPhongThi.Enabled = false;
                    dgvPhongThi.Enabled = true;
                    dgvDiaDiemThi.Enabled = true;

                    ROOMTEST tgz = GetPhongThiWithThongTin();
                    tg.LocationID = tgz.LocationID;
                    tg.RoomTestName = tgz.RoomTestName;
                    tg.MaxSeatMount = tgz.MaxSeatMount;
                    tg.MaxSupervisor = tgz.MaxSupervisor;

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Sửa thông tin phòng thi thành công",
                                        "Thông tin",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thông tin phòng thi thất bại\n" + ex.Message,
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }

                    LoadDgvPhongThi();
                }

                return;
            }
        }

        private void btnXoaPhongThi_Click(object sender, EventArgs e)
        {
            if (btnXoaPhongThi.Text == "Xóa phòng thi")
            {
                ROOMTEST rt = GetPhongThiWithID();
                if (rt.RoomTestID == 0)
                {
                    MessageBox.Show("Chưa có phòng thi nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Đồng chí có chắc chắn xóa phòng thi " + rt.RoomTestName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                rt.Status = 0;
                db.SaveChanges();

                MessageBox.Show("Xóa thông tin phòng thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvPhongThi();

                return;
            }

            if (btnXoaPhongThi.Text == "Hủy")
            {
                btnXoaPhongThi.Text = "Xóa phòng thi";
                btnThemPhongThi.Text = "Thêm phòng thi";
                btnSuaPhongThi.Text = "Sửa phòng thi";

                btnSuaPhongThi.Enabled = true;
                btnThemPhongThi.Enabled = true;

                dgvPhongThi.Enabled = true;
                dgvDiaDiemThi.Enabled = true;
                btnXoaDiaDiemThi.Enabled = true;
                btnThemDiaDiemThi.Enabled = true;
                btnSuaDiaDiemThi.Enabled = true;
                groupThongTinPhongThi.Enabled = false;

                UpdateDetailPhongThi();

                return;
            }
        }
        #endregion

        #endregion
    }
}
