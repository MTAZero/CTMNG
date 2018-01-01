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
    public partial class FrmChucVu : Form
    {
        private int index = 0;
        private int index1 = 0;

        #region Constructor
        public FrmChucVu()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void LoadDgv()
        {
            dgvChucVu.DataSource = DAO.PositionDAO.DanhSach(txtTimKiem.Text);

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
            txtPositionCode.DataBindings.Clear();
            txtPositionName.DataBindings.Clear();
            txtPermission.DataBindings.Clear();
        }
        private void AddBinding()
        {
            ClearBinding();

            txtPositionCode.DataBindings.Add(new Binding("Text", dgvChucVu.DataSource, "PositionCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtPositionName.DataBindings.Add(new Binding("Text", dgvChucVu.DataSource, "PositionName", true, DataSourceUpdateMode.OnPropertyChanged));
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
                    PositionDTO tg = GetThongTin();

                    DAO.PositionDAO.Them(tg);

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
            PositionDTO tg = GetThongTin();

            if (tg.PositionID == 0)
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
                    DAO.PositionDAO.Sua(tg);
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
                PositionDTO tg = GetThongTin();

                if (tg.PositionID == 0)
                {
                    MessageBox.Show("Danh sách chức vụ đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa chức vụ " + tg.PositionName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                DAO.PositionDAO.Xoa(tg);

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
            if (txtPositionCode.Text == "")
            {
                MessageBox.Show("Mã chức vụ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mode ==1 && !DAO.PositionDAO.KiemTraMa(txtPositionCode.Text))
            {
                MessageBox.Show("Mã chức vụ đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPositionName.Text == "")
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

        private PositionDTO GetThongTin()
        {
            PositionDTO ans = new PositionDTO();

            ans.PositionCode = txtPositionCode.Text;
            ans.PositionName = txtPositionName.Text;
            ans.Permission = (int)txtPermission.Value;

            try
            {
                ans.PositionID = (int)dgvChucVu.SelectedRows[0].Cells["PositionID"].Value;
            }
            catch
            {
                ans.PositionID = 0;
            }

            return ans;
        }

        private void ClearControl()
        {
            ClearBinding();

            txtPositionCode.Text = "";
            txtPositionName.Text = "";
            txtPermission.Value = 1;
        }

        #endregion
    }
}
