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
    public partial class FrmRpThiSinhDangKyTheoMonThi : Form
    {
        private SCHEDULE sc = new SCHEDULE();
        private ExonSystem db = DAO.DBService.db;

        #region constructor
        public FrmRpThiSinhDangKyTheoMonThi(SCHEDULE tg)
        {
            InitializeComponent();
            sc = tg;
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void FrmRpLichThiTheoCaThi_Load(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin của ca thi
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == sc.ContestID).FirstOrDefault();
                SUBJECT subject = db.SUBJECTS.Where(p => p.SubjectID == sc.SubjectID).FirstOrDefault();
                
                // truyền table vào trong report
                int i = 1;
                
                ThiSinhDangKyBindingSource.DataSource = (
                               from tt in db.REGISTERS.Where(pz => pz.Status > 0 && pz.ContestID == kithi.ContestID).ToList()
                               from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && pz.RegisterID == tt.RegisterID).ToList()
                               from dk in db.CONTESTANTS_SUBJECTS.Where(pz=>pz.Status>0 && pz.ContestantID == ts.ContestantID && pz.SubjectID == subject.SubjectID).ToList()
                               select new
                               {
                                   SBD = ts.ContestantCode,
                                   STT = i++,
                                   HoTen = tt.FullName,
                                   NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)tt.DOB).ToString("dd/MM/yyyy"),
                                   GioiTinh = (tt.Sex == 0) ? "Nữ" : "Nam",
                                   CMND = tt.IdentityCardNumber,
                                   DiemThi = (db.ANSWERSHEETS.Where(z=>z.Status>0 && z.ContestantTestID == ts.ContestantID).FirstOrDefault() == null) ? "" :
                                             (db.ANSWERSHEETS.Where(z=>z.Status>0 && z.ContestantTestID == ts.ContestantID).FirstOrDefault().TestScores).ToString()
                               }
                              ).ToList();

                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("SubjectName",subject.SubjectName),
                    new ReportParameter("RegisterDate",DAO.Helper.ConvertUnixToDateTime((int) kithi.BeginRegistration).ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
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
