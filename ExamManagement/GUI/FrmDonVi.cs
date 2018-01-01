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
    public partial class FrmDonVi : Form
    {
        private int index = 0;
        private int index1 = 0;

        #region Constructor
        public FrmDonVi()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void LoadDgv()
        {
            dgvDonVi.DataSource = DAO.DepartmentDAO.DanhSachDonVi(txtTimKiem.Text);

            index = index1;

            SetIndex();        
        }

        private void InitControl()
        {
            // dgv don vi
            dgvDonVi.AutoGenerateColumns = false;

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dgvDonVi.Columns["DepartmentIDParent"];
            column.DataSource = DAO.DepartmentDAO.DanhSachDonVicbx();
            column.DisplayMember = "DepartmentName";
            column.ValueMember = "DepartmentID";

            // cbx don vi chu quan
            cbxDonViChuQuan.DataSource = DAO.DepartmentDAO.DanhSachDonVicbx();
            cbxDonViChuQuan.DisplayMember = "DepartmentName";
            cbxDonViChuQuan.ValueMember = "DepartmentID";

            // groupthongtin
            groupThongTin.Enabled = false;
        }

        private void ClearBinding()
        {
            txtMa.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtCapDo.DataBindings.Clear();
            cbxDonViChuQuan.DataBindings.Clear();
        }
        private void AddBinding()
        {
            ClearBinding();

            txtMa.DataBindings.Add(new Binding("Text", dgvDonVi.DataSource, "DepartmentCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTen.DataBindings.Add(new Binding("Text", dgvDonVi.DataSource, "DepartmentName", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCapDo.DataBindings.Add(new Binding("Text", dgvDonVi.DataSource, "Level", true, DataSourceUpdateMode.OnPropertyChanged));
            cbxDonViChuQuan.DataBindings.Add(new Binding("SelectedValue", dgvDonVi.DataSource, "DepartmentIDParent", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void SetIndex()
        {
            try
            {
                dgvDonVi.Rows[index].Selected = true;
                dgvDonVi.CurrentCell = dgvDonVi.Rows[index].Cells[1];
            }
            catch { }

            dgvDonVi.Select();
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

                dgvDonVi.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check(1))
                {
                    DepartmentDTO tg = GetDonVi();

                    DAO.DepartmentDAO.ThemDonVi(tg);

                    MessageBox.Show("Thêm thông tin đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDonVi_Load(sender, e);

                    btnThem.Text = "Thêm";
                    btnXoa.Text = "Xóa";
                    btnSua.Enabled = true;

                    dgvDonVi.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra trống
            DepartmentDTO tg = GetDonVi();

            if (tg.DepartmentID == 0)
            {
                MessageBox.Show("Danh sách đơn vị đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // sửa
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnThem.Enabled = false;

                dgvDonVi.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                return;
            }

            // lưu
            if (btnSua.Text == "Lưu")
            {
                if (Check(0))
                {

                    tg = GetDonVi();
                    MessageBox.Show("Sửa thông tin đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAO.DepartmentDAO.Sua(tg);
                    FrmDonVi_Load(sender, e);

                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";
                    btnThem.Enabled = true;

                    dgvDonVi.Enabled = true;
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
                DepartmentDTO tg = GetDonVi();

                if (tg.DepartmentID == 0)
                {
                    MessageBox.Show("Danh sách đơn vị đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa đơn vị " + tg.DepartmentName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                DAO.DepartmentDAO.Xoa(tg);

                MessageBox.Show("Xóa thông tin đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dgvDonVi.Enabled = true;
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
            if (dgvDonVi.SelectedRows.Count > 0)
            {
                index1 = index;
                index = dgvDonVi.SelectedRows[0].Index;
            }
        }
        #endregion

        #region hàm chức năng

        private bool Check(int mode)
        {
            /// mode = 0 : sua
            /// mode = 1 : them 
            if (txtMa.Text == "")
            {
                MessageBox.Show("Mã đơn vị không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mode == 1 && !DAO.DepartmentDAO.KiemTraMaDonVi(txtMa.Text)) 
            {
                MessageBox.Show("Mã đơn vị đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên đơn vị không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCapDo.Text == "")
            {
                MessageBox.Show("Cấp độ đơn vị không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private DepartmentDTO GetDonVi()
        {
            DepartmentDTO ans = new DepartmentDTO();

            ans.DepartmentCode = txtMa.Text;
            ans.DepartmentName = txtTen.Text;
            ans.DepartmentIDParent = (int) cbxDonViChuQuan.SelectedValue;
            ans.Level = (int)txtCapDo.Value;

            try
            {
                ans.DepartmentID = (int) dgvDonVi.SelectedRows[0].Cells["DepartmentID"].Value;
            }
            catch
            {
                ans.DepartmentID = 0;
            }

            return ans;
        }

        private void ClearControl()
        {
            ClearBinding();

            txtMa.Text = "";
            txtTen.Text = "";
            txtCapDo.Value = 1;
            cbxDonViChuQuan.SelectedIndex = 0;

        }

        #endregion
    }
}
