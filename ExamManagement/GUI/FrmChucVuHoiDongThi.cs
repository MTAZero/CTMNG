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
    public partial class FrmChucVuHoiDongThi : Form
    {
        private int index = 0;
        private int index1 = 0;

        #region Constructor
        public FrmChucVuHoiDongThi()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void LoadDgv()
        {
            dgvChucVu.DataSource = DAO.ExaminationCouncil_PositionDAO.DanhSach(txtTimKiem.Text);

            index = index1;

            SetIndex();        
        }

        private void InitControl()
        {
            // dgv don vi
            dgvChucVu.AutoGenerateColumns = false;

            // groupthongtin
            groupThongTin.Enabled = false;
        }

        private void ClearBinding()
        {
            txtExaminationCouncil_PositionCode.DataBindings.Clear();
            txtExaminationCouncil_PositionCodeName.DataBindings.Clear();
            txtPermission.DataBindings.Clear();
        }
        private void AddBinding()
        {
            ClearBinding();

            txtExaminationCouncil_PositionCode.DataBindings.Add(new Binding("Text", dgvChucVu.DataSource, "ExaminationCouncil_PositionCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtExaminationCouncil_PositionCodeName.DataBindings.Add(new Binding("Text", dgvChucVu.DataSource, "ExaminationCouncil_PositionName", true, DataSourceUpdateMode.OnPropertyChanged));
            txtPermission.DataBindings.Add(new Binding("Text", dgvChucVu.DataSource, "Permission", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void SetIndex()
        {
            try
            {
                dgvChucVu.Rows[index].Selected = true;
                dgvChucVu.CurrentCell = dgvChucVu.Rows[index].Cells[1];
            }
            catch { }

            dgvChucVu.Select();
        }

        private void FrmDonVi_Load(object sender, EventArgs e)
        {
            LoadDgv();
            InitControl();
            AddBinding();
            SetIndex();
        }
        #endregion

        #region sự kiện
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            index = 0;
            index1 = 0;

            FrmDonVi_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnSua.Enabled = false;

                dgvChucVu.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check(1))
                {
                    ExaminationCouncil_PositionDTO tg = GetThongTin();

                    DAO.ExaminationCouncil_PositionDAO.Them(tg);

                    MessageBox.Show("Thêm thông tin chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDonVi_Load(sender, e);

                    btnThem.Text = "Thêm";
                    btnXoa.Text = "Xóa";
                    btnSua.Enabled = true;

                    dgvChucVu.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra trống
            ExaminationCouncil_PositionDTO tg = GetThongTin();

            if (tg.ExaminationCouncil_PositionID == 0)
            {
                MessageBox.Show("Danh sách chức vụ đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // sửa
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnThem.Enabled = false;

                dgvChucVu.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                return;
            }

            // lưu
            if (btnSua.Text == "Lưu")
            {
                if (Check(0))
                {

                    tg = GetThongTin();
                    MessageBox.Show("Sửa thông tin chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAO.ExaminationCouncil_PositionDAO.Sua(tg);
                    FrmDonVi_Load(sender, e);

                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";
                    btnThem.Enabled = true;

                    dgvChucVu.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Xóa")
            {
                ExaminationCouncil_PositionDTO tg = GetThongTin();

                if (tg.ExaminationCouncil_PositionID == 0)
                {
                    MessageBox.Show("Danh sách chức vụ đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa chức vụ " + tg.ExaminationCouncil_PositionName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                DAO.ExaminationCouncil_PositionDAO.Xoa(tg);

                MessageBox.Show("Xóa thông tin chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDonVi_Load(sender, e);
                return;
            }

            if (btnXoa.Text == "Hủy")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Text = "Xóa";
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                dgvChucVu.Enabled = true;
                groupThongTin.Enabled = false;
                btnTimKiem.Enabled = true;

                AddBinding();

                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvDonVi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChucVu.SelectedRows.Count > 0)
            {
                index1 = index;
                index = dgvChucVu.SelectedRows[0].Index;
            }
        }
        #endregion

        #region hàm chức năng

        private bool Check(int mode)
        {
            /// mode = 0 la sua
            /// mode = 1 la them
            if (txtExaminationCouncil_PositionCode.Text == "")
            {
                MessageBox.Show("Mã chức vụ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mode == 1 && !DAO.ExaminationCouncil_PositionDAO.KiemTraMa(txtExaminationCouncil_PositionCode.Text))
            {
                MessageBox.Show("Mã chức vụ đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtExaminationCouncil_PositionCodeName.Text == "")
            {
                MessageBox.Show("Tên chức vụ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPermission.Text == "")
            {
                MessageBox.Show("Quyền hạn chức vụ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private ExaminationCouncil_PositionDTO GetThongTin()
        {
            ExaminationCouncil_PositionDTO ans = new ExaminationCouncil_PositionDTO();

            ans.ExaminationCouncil_PositionCode = txtExaminationCouncil_PositionCode.Text;
            ans.ExaminationCouncil_PositionName = txtExaminationCouncil_PositionCodeName.Text;
            ans.Permission = (int)txtPermission.Value;

            try
            {
                ans.ExaminationCouncil_PositionID = (int)dgvChucVu.SelectedRows[0].Cells["ExaminationCouncil_PositionID"].Value;
            }
            catch
            {
                ans.ExaminationCouncil_PositionID = 0;
            }

            return ans;
        }

        private void ClearControl()
        {
            ClearBinding();

            txtExaminationCouncil_PositionCode.Text = "";
            txtExaminationCouncil_PositionCodeName.Text = "";
            txtPermission.Value = 1;
        }

        #endregion
    }
}
