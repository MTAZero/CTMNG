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
    public partial class FrmHocPhan : Form
    {
        private int index = 0;
        private int index1 = 0;

        #region Constructor
        public FrmHocPhan()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void LoadDgv()
        {
            // data source
            dgvHocPhan.DataSource = DAO.SubjectDAO.DanhSach(txtTimKiem.Text);

            index = index1;      
            SetIndex();        
        }

        private void InitControl()
        {
            // dgv don vi
            dgvHocPhan.AutoGenerateColumns = false;

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dgvHocPhan.Columns["DepartmentID"];
            column.DataSource = DAO.DepartmentDAO.DanhSachDonVi();
            column.DisplayMember = "DepartmentName";
            column.ValueMember = "DepartmentID";

            // groupthongtin
            groupThongTin.Enabled = false;

            // cbx DepartmentID
            cbxDepartmentID.DataSource = DAO.DepartmentDAO.DanhSachDonVicbx();
            cbxDepartmentID.ValueMember = "DepartmentID";
            cbxDepartmentID.DisplayMember = "DepartmentName";
        }

        private void ClearBinding()
        {
            txtSubjectCode.DataBindings.Clear();
            txtSubjectName.DataBindings.Clear();
            cbxDepartmentID.DataBindings.Clear();
        }
        private void AddBinding()
        {
            ClearBinding();

            txtSubjectCode.DataBindings.Add(new Binding("Text", dgvHocPhan.DataSource, "SubjectCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSubjectName.DataBindings.Add(new Binding("Text", dgvHocPhan.DataSource, "SubjectName", true, DataSourceUpdateMode.OnPropertyChanged));
            cbxDepartmentID.DataBindings.Add(new Binding("SelectedValue", dgvHocPhan.DataSource, "DepartmentID", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void SetIndex()
        {
            try
            {
                dgvHocPhan.Rows[index].Selected = true;
                dgvHocPhan.CurrentCell = dgvHocPhan.Rows[index].Cells[1];
            }
            catch { }

            dgvHocPhan.Select();
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

                dgvHocPhan.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check(1))
                {
                    SubjectDTO tg = GetThongTin();

                    DAO.SubjectDAO.Them(tg);

                    MessageBox.Show("Thêm thông tin học phần thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDonVi_Load(sender, e);

                    btnThem.Text = "Thêm";
                    btnXoa.Text = "Xóa";
                    btnSua.Enabled = true;

                    dgvHocPhan.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra trống
            SubjectDTO tg = GetThongTin();

            if (tg.SubjectID == 0)
            {
                MessageBox.Show("Danh sách học phần đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // sửa
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnThem.Enabled = false;

                dgvHocPhan.Enabled = false;
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
                    MessageBox.Show("Sửa thông tin học phần thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAO.SubjectDAO.Sua(tg);
                    FrmDonVi_Load(sender, e);

                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";
                    btnThem.Enabled = true;

                    dgvHocPhan.Enabled = true;
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
                SubjectDTO tg = GetThongTin();

                if (tg.SubjectID == 0)
                {
                    MessageBox.Show("Danh sách học phần đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa học phần " + tg.SubjectName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                DAO.SubjectDAO.Xoa(tg);

                MessageBox.Show("Xóa thông tin học phần thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dgvHocPhan.Enabled = true;
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
            if (dgvHocPhan.SelectedRows.Count > 0)
            {
                index1 = index;
                index = dgvHocPhan.SelectedRows[0].Index;
            }
        }
        #endregion

        #region hàm chức năng

        private bool Check(int mode)
        {
            /// mode = 0 la sua
            /// mode = 1 la them
            if (txtSubjectCode.Text == "")
            {
                MessageBox.Show("Tên học phần không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mode ==1 && !DAO.SubjectDAO.KiemTraMa(txtSubjectCode.Text))
            {
                MessageBox.Show("Mã học phần đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("Tên học phần không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private SubjectDTO GetThongTin()
        {
            SubjectDTO ans = new SubjectDTO();

            ans.SubjectCode = txtSubjectCode.Text;
            ans.SubjectName = txtSubjectName.Text;
            ans.DepartmentID = (int) cbxDepartmentID.SelectedValue;
            ans.Status = 1;

            try
            {
                ans.SubjectID = (int)dgvHocPhan.SelectedRows[0].Cells["SubjectID"].Value;
            }
            catch
            {
                ans.SubjectID = 0;
            }

            return ans;
        }

        private void ClearControl()
        {
            ClearBinding();

            txtSubjectCode.Text = "";
            txtSubjectName.Text = "";
            cbxDepartmentID.SelectedIndex = 0;
        }

        #endregion
    }
}
