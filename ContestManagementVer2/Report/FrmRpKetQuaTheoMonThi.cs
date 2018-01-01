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
    public partial class FrmRpKetQuaTheoMonThi : Form
    {
        private SCHEDULE sc = new SCHEDULE();
        private ExonSystem db = DAO.DBService.db;

        #region constructor
        public FrmRpKetQuaTheoMonThi(SCHEDULE tg)
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

                CSDL_Luu_Tru.MTA_Quiz_Main z1 = new CSDL_Luu_Tru.MTA_Quiz_Main();
                
                ThiSinhDangKyBindingSource.DataSource = (
                               from tt in db.REGISTERS.Where(pz => pz.Status > 0 && pz.ContestID == kithi.ContestID).ToList()
                               from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && pz.RegisterID == tt.RegisterID).ToList()
                               from lt in db.CONTESTANTS_SHIFTS.Where(pz=>pz.Status>0 && pz.ContestantID == ts.ContestantID).ToList()
                               from dk in db.SCHEDULES.Where(pz=>pz.Status>0 && pz.SubjectID == subject.SubjectID && pz.ScheduleID == lt.ScheduleID)
                               select new
                               {
                                   SBD = ts.ContestantCode,
                                   STT = i++,
                                   HoTen = tt.FullName,
                                   NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)tt.DOB).ToString("dd/MM/yyyy"),
                                   GioiTinh = (tt.Sex == 0) ? "Nữ" : "Nam",
                                   CMND = tt.IdentityCardNumber,
                                   DiemThi =  (
                                                (
                                                    from ct in z1.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == lt.ContestantShiftID).ToList()
                                                    from ans in z1.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID && k.Status > 0).ToList()
                                                    select ans
                                                 )
                                                 .FirstOrDefault() == null
                                            )
                                            ? ""
                                            :
                                                (
                                                    from ct in z1.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == lt.ContestantShiftID).ToList()
                                                    from ans in z1.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID && k.Status > 0).ToList()
                                                    select ans
                                                 )
                                                 .FirstOrDefault()
                                                 .TestScores
                                                 .ToString()
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
