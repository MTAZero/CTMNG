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
    public partial class FrmChucVuCanBo : Form
    {
        #region constructor
        public FrmChucVuCanBo()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadForm
        private void InitControl()
        {
            /// cbx Position
            cbxPosition.DataSource = DAO.PositionDAO.DanhSach();
            cbxPosition.DisplayMember = "PositionName";
            cbxPosition.ValueMember = "PositionID";

            // cbx Department
            cbxDepartment.DataSource = DAO.DepartmentDAO.DanhSachDonVi();
            cbxDepartment.DisplayMember = "DepartmentName";
            cbxDepartment.ValueMember = "DepartmentID";

            // cbx Staff
            cbxStaff.DataSource = DAO.StaffDAO.DanhSachCanBoStaffDTO();
            cbxStaff.DisplayMember = "FullName";
            cbxStaff.ValueMember = "StaffID";

            txtStaffName.Text = ((StaffDTO)cbxStaff.SelectedItem).FullName;
            cbxDepartment.SelectedValue = ((StaffDTO)cbxStaff.SelectedItem).DepartmentID;
        }

        private void LoadDgvCanBoChucVu()
        {
            int ma = (int)cbxStaff.SelectedValue;
            int i = 0;
            dgvChucVuCanBo.DataSource = (from nv in DAO.StaffDAO.DanhSachCanBoStaffDTO()
                                         from cv in DAO.PositionDAO.DanhSach()
                                         from pq in DAO.Staffs_PositionDAO.DanhSach()
                                         where pq.StaffID == nv.StaffID
                                         where pq.PositionID == cv.PositionID
                                         where pq.StaffID == ma
                                         select new
                                         {
                                             Index = ++i,
                                             StaffPositionID = pq.StaffPositionID,
                                             StaffID = pq.StaffID,
                                             PositionID = pq.PositionID,
                                             FullName = nv.FullName,
                                             PositionName = cv.PositionName,
                                             DepartmentID = nv.DepartmentID
                                         })
                                         .ToList();
        }

        private void ClearBinding()
        {
            cbxPosition.DataBindings.Clear();
        }

        private void AddBinding()
        {
            ClearBinding();
            cbxPosition.DataBindings.Add(new Binding("SelectedValue", dgvChucVuCanBo.DataSource, "PositionID", true, DataSourceUpdateMode.OnPropertyChanged));
        }
        private void FrmChucVuCanBo_Load(object sender, EventArgs e)
        {
            InitControl();
            LoadDgvCanBoChucVu();

            /// add binding
            AddBinding(); 

            groupThongTin.Enabled = false;
        }
        #endregion

        #region sự kiện ngầm
        private void cbxStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtStaffName.Text = ((StaffDTO)cbxStaff.SelectedItem).FullName;
                cbxDepartment.SelectedValue = ((StaffDTO)cbxStaff.SelectedItem).DepartmentID;

                LoadDgvCanBoChucVu();
                AddBinding();
            }
            catch
            {

            }
        }
        #endregion

        #region sự kiện
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Xóa")
            {
                Staffs_PositionsDTO tg = GetThongTin();
                if (tg.StaffPositionID == 0)
                {
                    MessageBox.Show("Danh sách chức vụ của cán bộ " + txtStaffName.Text + " đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa chức vụ này của cán bộ " + txtStaffName.Text + " không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;
                DAO.Staffs_PositionDAO.Xoa(tg);
                MessageBox.Show("Xóa thành công thông tin chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvCanBoChucVu();
                AddBinding();
                return;
            }

            if (btnXoa.Text == "Hủy")
            {
                btnThem.Text = "Thêm";
                btnXoa.Text = "Xóa";

                dgvChucVuCanBo.Enabled = true;
                groupThongTin.Enabled = false;
                AddBinding();
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Lưu";
                btnXoa.Text = "Hủy";

                dgvChucVuCanBo.Enabled = false;
                groupThongTin.Enabled = true;
                cbxPosition.SelectedIndex = 0;

                return;
            }

            if (btnThem.Text == "Lưu" && Check())
            {
                btnThem.Text = "Thêm";
                btnXoa.Text = "Xóa";

                dgvChucVuCanBo.Enabled = true;
                groupThongTin.Enabled = false;

                Staffs_PositionsDTO tg = GetThongTin();
                DAO.Staffs_PositionDAO.Them(tg);

                MessageBox.Show("Thêm thông tin chức vụ cán bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvCanBoChucVu();
                AddBinding();

                return;
            }
        }
        #endregion

        #region Hàm chức năng
        private bool Check()
        {
            int cnt = (from pc in DAO.Staffs_PositionDAO.DanhSach()
                       where pc.StaffID == ((StaffDTO)cbxStaff.SelectedItem).StaffID
                       where pc.PositionID == ((PositionDTO)cbxPosition.SelectedItem).PositionID
                       select pc
                     ).Count();
            if (cnt > 0)
            {
                MessageBox.Show("Cán bộ này đã được phân công cho chức vụ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private Staffs_PositionsDTO GetThongTin()
        {
            Staffs_PositionsDTO ans = new Staffs_PositionsDTO();
            ans.StaffID = (int)cbxStaff.SelectedValue;
            ans.PositionID = (int)cbxPosition.SelectedValue;

            try
            {
                ans.StaffPositionID = (int)dgvChucVuCanBo.SelectedRows[0].Cells["StaffPositionID"].Value;
            }
            catch
            {
                ans.StaffPositionID = 0;
            }

            return ans;
        }
        #endregion
    }
}
