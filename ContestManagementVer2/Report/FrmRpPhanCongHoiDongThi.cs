using ContestManagementVer2.CSDL_Exonsytem;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContestManagementVer2.Report
{
    public partial class FrmRpPhanCongHoiDongThi : Form
    {
        private LOCATION lc = new LOCATION();
        private ExonSystem db = DAO.DBService.db;

        #region constructor
        public FrmRpPhanCongHoiDongThi(LOCATION tg)
        {
            InitializeComponent();
            lc = tg;
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void FrmRpLichThiTheoCaThi_Load(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin của ca thi
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == lc.ContestID).FirstOrDefault();
                
                // truyền table vào trong report
                int i = 1;
                HoiDongThiBindingSource.DataSource = (
                               from pc in db.EXAMINATIONCOUNCIL_STAFFS.Where(p=>p.Status>0 && p.ContestID == kithi.ContestID && p.LocationID == lc.LocationID).ToList()
                               from nv in db.STAFFS.Where(p=>p.Status>0 && p.StaffID == pc.StaffID).ToList()
                               from cv in db.EXAMINATIONCOUNCIL_POSITIONS.Where(p=>p.ExaminationCouncil_PositionID == pc.ExaminationCouncil_PositionID && p.Status>0).ToList()
                               select new
                               {
                                   STT = i++,
                                   HoVaTen = nv.FullName,
                                   ChucVu = cv.ExaminationCouncil_PositionName,
                                   TaiKhoan = pc.UserName,
                                   MatKhau = pc.Password
                               }
                              ).ToList();

                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName),
                    new ReportParameter("LocationName",lc.LocationName),
                    new ReportParameter("Date",DAO.Helper.ConvertUnixToDateTime((int)kithi.CreatedDate).ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
                };
                this.reportViewer1.LocalReport.SetParameters(listPara);


                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        #endregion
    }
}
