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
    public partial class FrmRpKetQuaTheoCaThi : Form
    {
        private DIVISION_SHIFTS dv = new DIVISION_SHIFTS();
        private ExonSystem db = DAO.DBService.db;

        #region constructor

        public FrmRpKetQuaTheoCaThi(DIVISION_SHIFTS tg)
        {
            InitializeComponent();
            dv = tg;
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void FrmRpLichThiTheoCaThi_Load(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin của ca thi
                ROOMTEST roomTest = db.ROOMTESTS.Where(p => p.RoomTestID == dv.RoomTestID).FirstOrDefault();
                LOCATION location = db.LOCATIONS.Where(p => p.LocationID == roomTest.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == location.ContestID).FirstOrDefault();
                SHIFT shift = db.SHIFTS.Where(p => p.ShiftID == dv.ShiftID).FirstOrDefault();
                STAFF staff = db.STAFFS.Where(p => p.StaffID == kithi.CreatedStaffID).FirstOrDefault();

                CSDL_Luu_Tru.MTA_Quiz_Main z = new CSDL_Luu_Tru.MTA_Quiz_Main();
                
                // truyền table vào trong report
                int i = 1;
                KetQuaThiTheoCaThiBindingSource.DataSource = (
                               from lt in db.CONTESTANTS_SHIFTS.Where(pz => pz.Status == 1 && pz.ShiftID == dv.DivisionShiftID).ToList()
                               from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && lt.ContestantID == pz.ContestantID).ToList()
                               from tt in db.REGISTERS.Where(pz => pz.Status > 0 && pz.ContestID == kithi.ContestID && pz.RegisterID == ts.RegisterID).ToList()
                               from mt in db.SCHEDULES.Where(pz => pz.Status == 1 && pz.ContestID == kithi.ContestID && pz.ScheduleID == lt.ScheduleID).ToList()
                               select new
                               {
                                   SBD = ts.ContestantCode,
                                   STT = i++,
                                   HoTen = tt.FullName,
                                   NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)tt.DOB).ToString("dd/MM/yyyy"),
                                   MonThi = db.SUBJECTS.Where(p => p.SubjectID == mt.SubjectID).FirstOrDefault().SubjectName,
                                   GioiTinh = (tt.Sex == 0) ? "Nữ" : "Nam",
                                   DiemThi = (
                                                (
                                                    from ct in z.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == lt.ContestantShiftID).ToList()
                                                    from ans in z.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID && k.Status > 0).ToList()
                                                    select ans
                                                 )
                                                 .FirstOrDefault() == null
                                            )
                                            ? ""
                                            :
                                                (
                                                    from ct in z.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == lt.ContestantShiftID).ToList()
                                                    from ans in z.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID && k.Status > 0).ToList()
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
                    new ReportParameter("LocationName",location.LocationName.ToUpper()),
                    new ReportParameter("RoomTestName",roomTest.RoomTestName.ToLower()),
                    new ReportParameter("ShiftName",shift.ShiftName.ToLower()),
                    new ReportParameter("Date",DateTime.Now.ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
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
