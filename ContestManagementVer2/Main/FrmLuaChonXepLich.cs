using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.XepLichThi;
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
    public partial class FrmLuaChonXepLich : MetroForm
    {
        private CONTEST kithi = new CONTEST();
        private ExonSystem db = DAO.DBService.db;

        #region Hàm khởi tạo
        public FrmLuaChonXepLich(CONTEST _ct)
        {
            InitializeComponent();
            kithi = _ct;
            DAO.DBService.Reload();
        }
        #endregion

        #region Sự kiện
        private void btnXepLich_Click(object sender, EventArgs e)
        {
            if (!radUuTienMonThi.Checked && !radUuTienThiSinh.Checked)
            {
                MessageBox.Show("Chưa có kiểu xếp lịch nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            XepLich lichthi = new XepLich(kithi);

            int type = 0;
            if (radUuTienMonThi.Checked) type = 1; else type = 0;
            int z = lichthi.Run(type);

            // nếu z == 0 => xếp lịch bị lỗi
            if (z == 0) this.Close();

            kithi.Status = 5;
            db.SaveChanges();

            MessageBox.Show("Xếp lịch thành công",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.Close();
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
