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
    public partial class FrmLoaiViPham : Form
    {
        private int index = 0;
        private int index1 = 0;

        #region Constructor
        public FrmLoaiViPham()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void LoadDgv()
        {
            dgvLoaiViPham.DataSource = DAO.ViolationDAO.DanhSach(txtTimKiem.Text);

            index = index1;

            SetIndex();        
        }

        private void InitControl()
        {
            // dgv don vi
            dgvLoaiViPham.AutoGenerateColumns = false;

            // groupthongtin
            groupThongTin.Enabled = false;
        }

        private void ClearBinding()
        {
            txtViolationName.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            txtLevel.DataBindings.Clear();
        }
        private void AddBinding()
        {
            ClearBinding();

            txtViolationName.DataBindings.Add(new Binding("Text", dgvLoaiViPham.DataSource, "ViolationName", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDescription.DataBindings.Add(new Binding("Text", dgvLoaiViPham.DataSource, "Description", true, DataSourceUpdateMode.OnPropertyChanged));
            txtLevel.DataBindings.Add(new Binding("Text", dgvLoaiViPham.DataSource, "Level", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void SetIndex()
        {
            try
            {
                dgvLoaiViPham.Rows[index].Selected = true;
                dgvLoaiViPham.CurrentCell = dgvLoaiViPham.Rows[index].Cells[1];
            }
            catch { }

            dgvLoaiViPham.Select();
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

                dgvLoaiViPham.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check(1))
                {
                    ViolationDTO tg = GetThongTin();

                    DAO.ViolationDAO.Them(tg);

                    MessageBox.Show("Thêm thông tin loại vi phạm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDonVi_Load(sender, e);

                    btnThem.Text = "Thêm";
                    btnXoa.Text = "Xóa";
                    btnSua.Enabled = true;

                    dgvLoaiViPham.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra trống
            ViolationDTO tg = GetThongTin();

            if (tg.ViolationID == 0)
            {
                MessageBox.Show("Danh sách loại vi phạm đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // sửa
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnThem.Enabled = false;

                dgvLoaiViPham.Enabled = false;
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
                    MessageBox.Show("Sửa thông tin loại vi phạm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAO.ViolationDAO.Sua(tg);
                    FrmDonVi_Load(sender, e);

                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";
                    btnThem.Enabled = true;

                    dgvLoaiViPham.Enabled = true;
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
                ViolationDTO tg = GetThongTin();

                if (tg.ViolationID == 0)
                {
                    MessageBox.Show("Danh sách loại vi phạm đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa loại vi phạm " + tg.ViolationName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                DAO.ViolationDAO.Xoa(tg);

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

                dgvLoaiViPham.Enabled = true;
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
            if (dgvLoaiViPham.SelectedRows.Count > 0)
            {
                index1 = index;
                index = dgvLoaiViPham.SelectedRows[0].Index;
            }
        }
        #endregion

        #region hàm chức năng

        private bool Check(int mode)
        {
            /// mode = 0 la sua
            /// mode = 1 la them
            if (txtViolationName.Text == "")
            {
                MessageBox.Show("Tên loại vi phạm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDescription.Text == "")
            {
                MessageBox.Show("Mô tả vi phạm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtLevel.Text == "")
            {
                MessageBox.Show("Cấp độ vi phạm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private ViolationDTO GetThongTin()
        {
            ViolationDTO ans = new ViolationDTO();

            ans.ViolationName = txtViolationName.Text;
            ans.Description = txtDescription.Text;
            ans.Level = (int)txtLevel.Value;
            ans.Status = 1;

            try
            {
                ans.ViolationID = (int)dgvLoaiViPham.SelectedRows[0].Cells["ViolationID"].Value;
            }
            catch
            {
                ans.ViolationID = 0;
            }

            return ans;
        }

        private void ClearControl()
        {
            ClearBinding();

            txtViolationName.Text = "";
            txtDescription.Text = "";
            txtLevel.Value = 1;
        }

        #endregion
    }
}
