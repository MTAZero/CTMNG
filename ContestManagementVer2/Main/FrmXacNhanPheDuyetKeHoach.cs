using ContestManagementVer2.CSDL_Exonsytem;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContestManagementVer2.Main
{
    public partial class FrmXacNhanPheDuyetKeHoach : MetroForm
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();
        private STAFF nhanvien = new STAFF();

        #region constructor
        public FrmXacNhanPheDuyetKeHoach(CONTEST kt, STAFF nv)
        {
            InitializeComponent();
            DAO.DBService.Reload();

            kithi = kt;
            nhanvien = nv;
        }
        #endregion

        #region LoadForm
        private void FrmXacNhanPheDuyetKeHoach_Load(object sender, EventArgs e)
        {
            // load combobox cán bộ
            cbxCanBoPheDuyet.DataSource = db.STAFFS.Where(p => p.Status > 0).ToList();
            cbxCanBoPheDuyet.ValueMember = "StaffID";
            cbxCanBoPheDuyet.DisplayMember = "FullName";

            try
            {
                cbxCanBoPheDuyet.SelectedValue = nhanvien.StaffID;
            }
            catch { }
        }
        #endregion

        #region Hàm chức năng
        private bool Check()
        {
            if (txtSoKeHoach.Text == "")
            {
                MessageBox.Show("Số kế hoạch không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region Sự kiện
        private void btnPheDuyet_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    // nếu như mọi thông tin đều chính xác
                    kithi.Description = txtSoKeHoach.Text;
                    kithi.AcceptedStaffID = nhanvien.StaffID;
                    kithi.Status = 1;

                    db.SaveChanges();

                    MessageBox.Show("Phê duyệt thông tin kì thi thành công",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phê duyệt kì thi thất bại\n"+ex.Message,
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
