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
    public partial class FrmCanBo : Form
    {
        private int index = 0;
        private int index1 = 0;

        #region Constructor
        public FrmCanBo()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void LoadDgv()
        {
            // data source
            List<StaffDTO> cb = DAO.StaffDAO.DanhSachCanBoStaffDTO();
            dgvCanBo.DataSource = (from nv in cb
                                   from dv in DAO.DepartmentDAO.DanhSachDonVi()
                                   where nv.DepartmentID == dv.DepartmentID
                                   select new
                                   {
                                       StaffID = nv.StaffID,
                                       FullName = nv.FullName,
                                       DOB = nv.DOB.ToString("dd/MM/yyyy"),
                                       DOB2 = nv.DOB, 
                                       DepartmentID = dv.DepartmentName,
                                       Sex = (nv.Sex == 1) ? "Nam" : "Nữ",
                                       Username = nv.Username,
                                       Password = nv.Password, 
                                       IdentityCardNumber = nv.IdentityCardNumber,
                                       AcademicRank = nv.AcademicRank,
                                       Degree = nv.Degree,
                                       CurrentAddress = nv.CurrentAddress,
                                       MailAddress = nv.MailAddress,
                                       Status = nv.Status
                                   }
                                   )
                                   .ToList()
                                   .Where(t => t.FullName.Contains(txtTimKiem.Text) || t.DepartmentID.Contains(txtTimKiem.Text) || t.Sex.Contains(txtTimKiem.Text))
                                   .Select(t => t)
                                   .ToList();

            index = index1;      
            SetIndex();        
        }

        private void InitControl()
        {
            // dgv don vi
            dgvCanBo.AutoGenerateColumns = false;

            /// cbxDepartment
            cbxDepartmentID.DataSource = DAO.DepartmentDAO.DanhSachDonVi();
            cbxDepartmentID.DisplayMember = "DepartmentName";
            cbxDepartmentID.ValueMember = "DepartmentName";

            // cbx Sex
            List<DoiTuong> list = new List<DoiTuong>();
            list.Add(new DoiTuong(){ Value = 0, Name = "Nữ" });
            list.Add(new DoiTuong(){ Value = 1, Name = "Nam" });
            cbxSex.DataSource = list;

            cbxSex.DisplayMember = "Name";
            cbxSex.ValueMember = "Name";

            // groupthongtin
            groupThongTin.Enabled = false;
        }

        private void ClearBinding()
        {
            txtFullName.DataBindings.Clear();
            txtUserName.DataBindings.Clear();
            cbxDepartmentID.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            txtEmailAddress.DataBindings.Clear();
            txtAcademicRank.DataBindings.Clear();
            txtDegree.DataBindings.Clear();
            txtCurrentAddress.DataBindings.Clear();
            cbxSex.DataBindings.Clear();
            dateDOB.DataBindings.Clear();
            txtIdentityCardNumber.DataBindings.Clear();
        }
        private void AddBinding()
        {
            ClearBinding();

            txtFullName.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged));
            txtUserName.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "UserName", true, DataSourceUpdateMode.OnPropertyChanged));
            cbxDepartmentID.DataBindings.Add(new Binding("SelectedValue", dgvCanBo.DataSource, "DepartmentID", true, DataSourceUpdateMode.OnPropertyChanged));
            txtPassword.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "Password", true, DataSourceUpdateMode.OnPropertyChanged));
            txtEmailAddress.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "MailAddress", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAcademicRank.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "AcademicRank", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDegree.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "Degree", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCurrentAddress.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "CurrentAddress", true, DataSourceUpdateMode.OnPropertyChanged));
            cbxSex.DataBindings.Add(new Binding("SelectedValue", dgvCanBo.DataSource, "Sex", true, DataSourceUpdateMode.OnPropertyChanged));
            dateDOB.DataBindings.Add(new Binding("Value", dgvCanBo.DataSource, "DOB2", true, DataSourceUpdateMode.OnPropertyChanged));
            txtIdentityCardNumber.DataBindings.Add(new Binding("Text", dgvCanBo.DataSource, "IdentityCardNumber", true, DataSourceUpdateMode.OnPropertyChanged));      
        }

        private void SetIndex()
        {
            try
            {
                dgvCanBo.Rows[index].Selected = true;
                dgvCanBo.CurrentCell = dgvCanBo.Rows[index].Cells[1];
            }
            catch { }

            dgvCanBo.Select();
        }

        private void FrmDonVi_Load(object sender, EventArgs e)
        {
            LoadDgv();
            InitControl();
            AddBinding();
            SetIndex();

            txtConfirmPasword.Visible = false;
            labelConfirmPassword.Visible = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
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

                dgvCanBo.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check(1))
                {
                    StaffDTO tg = GetThongTin();

                    DAO.StaffDAO.Them(tg);

                    MessageBox.Show("Thêm thông tin cán bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDonVi_Load(sender, e);

                    btnThem.Text = "Thêm";
                    btnXoa.Text = "Xóa";
                    btnSua.Enabled = true;

                    dgvCanBo.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra trống
            StaffDTO tg = GetThongTin();

            if (tg.StaffID == 0)
            {
                MessageBox.Show("Danh sách cán bộ đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // sửa
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnThem.Enabled = false;

                dgvCanBo.Enabled = false;
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
                    MessageBox.Show("Sửa thông tin cán bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAO.StaffDAO.Sua(tg);
                    FrmDonVi_Load(sender, e);

                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";
                    btnThem.Enabled = true;

                    dgvCanBo.Enabled = true;
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
                StaffDTO tg = GetThongTin();

                if (tg.StaffID == 0)
                {
                    MessageBox.Show("Danh sách cán bộ đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin của cán bộ " + tg.FullName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                DAO.StaffDAO.Xoa(tg);

                MessageBox.Show("Xóa thông tin cán bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dgvCanBo.Enabled = true;
                groupThongTin.Enabled = false;
                btnTimKiem.Enabled = true;

                txtConfirmPasword.Visible = false;
                labelConfirmPassword.Visible = false;
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;

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
            if (dgvCanBo.SelectedRows.Count > 0)
            {
                index1 = index;
                index = dgvCanBo.SelectedRows[0].Index;
            }
        }
        #endregion

        #region hàm chức năng

        private bool Check(int mode)
        {
            /// mode = 0 la sua
            /// mode = 1 la them
            if (txtFullName.Text == "")
            {
                MessageBox.Show("Tên cán bộ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtIdentityCardNumber.Text == "")
            {
                MessageBox.Show("CMND không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtUserName.Text == "")
            {
                MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mode ==1 && !DAO.StaffDAO.KiemTraTenTaiKhoan(txtUserName.Text))
            {
                MessageBox.Show("Tài khoản đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mode == 1 && txtPassword.Text != txtConfirmPasword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEmailAddress.Text == "")
            {
                MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCurrentAddress.Text == "")
            {
                MessageBox.Show("Địa không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private StaffDTO GetThongTin()
        {
            StaffDTO ans = new StaffDTO();

            ans.FullName = txtFullName.Text;
            ans.Username = txtUserName.Text;
            ans.Password = txtPassword.Text;
            ans.MailAddress = txtEmailAddress.Text;
            ans.AcademicRank = txtAcademicRank.Text;
            ans.Degree = txtDegree.Text;
            ans.DOB = dateDOB.Value;
            ans.IdentityCardNumber = txtIdentityCardNumber.Text;
            ans.Sex = cbxSex.SelectedIndex;
            ans.CurrentAddress = txtCurrentAddress.Text;

            string selectedValue = (string)cbxDepartmentID.SelectedValue;
            var query = (from pb in DAO.DepartmentDAO.DanhSachDonVi()
                         where pb.DepartmentName == selectedValue
                         select new { pb.DepartmentID }
                         ).Single();

            ans.DepartmentID = (int) query.DepartmentID;
            ans.Status = 1;

            try
            {
                ans.StaffID = (int)dgvCanBo.SelectedRows[0].Cells["StaffID"].Value;
            }
            catch
            {
                ans.StaffID = 0;
            }

            return ans;
        }

        private void ClearControl()
        {
            ClearBinding();

            txtFullName.Text = "";
            txtUserName.Text = "";
            cbxDepartmentID.SelectedIndex = 0;
            txtPassword.Text = "";
            txtEmailAddress.Text = "";
            txtAcademicRank.Text = "";
            txtDegree.Text = "";
            txtCurrentAddress.Text = "";
            cbxSex.SelectedIndex = 0;
            txtIdentityCardNumber.Text = "";

            txtConfirmPasword.Visible = true;
            labelConfirmPassword.Visible = true;
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
        }

        #endregion
    }
}
