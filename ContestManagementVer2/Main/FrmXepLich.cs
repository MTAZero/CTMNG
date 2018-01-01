using ContestManagementVer2.CSDL_Exonsytem;
using EXON.Common;
using EXON.Data.Services;
using EXON_EM.Data.Service;
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
    public partial class FrmXepLich : MetroForm
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region  Hàm khởi tạo
        public FrmXepLich(CONTEST _kt)
        {
            InitializeComponent();
            kithi = _kt;
            DAO.DBService.Reload();
        }

        #endregion

        #region Sự kiện
        private void btnDanhSachDangKy_Click(object sender, EventArgs e)
        {
            //kithi = db.CONTESTS.Where(p => p.ContestID == 12).FirstOrDefault();
            ucDanhSachDangKy form = new ucDanhSachDangKy(kithi);
            panelMain.Controls.Clear();
            form.Dock = DockStyle.Fill;
            
            panelMain.Controls.Add(form);
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            if (kithi.Status != 4)
            {
                if (kithi.Status == 0 || kithi.Status == 1)
                {
                    if (kithi.EndRegistration < DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now))
                    {
                        kithi.Status = 4;
                        Contest_Service consv = new Contest_Service();
                        EXON_EM.Data.Model.CONTEST con = consv.Find(kithi.ContestID);
                        con.Status = 4;
                        try
                        {
                            consv.Update(con);
                            consv.Save();
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("Kì thi chưa hoàn thành đăng ký",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        return;
                    } 
                }
                
                if (kithi.Status == 2)
                {
                    MessageBox.Show("Kì thi đã bị hủy",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                if (kithi.Status != 4)
                {
                    MessageBox.Show("Kì thi đã được xếp lịch",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    ucLichThi form1 = new ucLichThi(kithi);
                    panelMain.Controls.Clear();
                    form1.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(form1);
                }
                return;
            }
            FrmLuaChonXepLich form = new FrmLuaChonXepLich(kithi);
            form.ShowDialog();
        }

        private void btnLichThi_Click(object sender, EventArgs e)
        {
            
            if (kithi.Status < 3)
            {
                MessageBox.Show("Kì thi chưa được xếp lịch",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            ucLichThi form = new ucLichThi(kithi);
            panelMain.Controls.Clear();
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
        }
        #endregion
    }
}
