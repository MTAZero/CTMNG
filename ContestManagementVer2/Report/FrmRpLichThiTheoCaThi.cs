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
    public partial class FrmRpLichThiTheoCaThi : Form
    {
        private DIVISION_SHIFTS dv = new DIVISION_SHIFTS();
        private ExonSystem db = DAO.DBService.db;

        #region constructor
        public FrmRpLichThiTheoCaThi()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmRpLichThiTheoCaThi(DIVISION_SHIFTS tg)
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
                ReportDataSet dataSet = new ReportDataSet();
                dataSet.Tables.Clear();

                ROOMTEST roomTest = db.ROOMTESTS.Where(p => p.RoomTestID == dv.RoomTestID).FirstOrDefault();
                LOCATION location = db.LOCATIONS.Where(p => p.LocationID == roomTest.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == location.ContestID).FirstOrDefault();
                SHIFT shift = db.SHIFTS.Where(p => p.ShiftID == dv.ShiftID).FirstOrDefault();
                STAFF staff = db.STAFFS.Where(p => p.StaffID == kithi.CreatedStaffID).FirstOrDefault();

                int i = 1;
                var lichthi = (
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
                                   QueQuan = tt.CurrentAddress
                               }
                              ).ToList();
                dataSet.Tables.Add(DAO.Helper.ToDataTable(lichthi));

                ReportDataSource rp = new ReportDataSource("LichThi", dataSet.Tables[0]);

                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("ShiftName",shift.ShiftName),
                    new ReportParameter("LocationName", location.LocationName),
                    new ReportParameter("RoomTestName", roomTest.RoomTestName),
                    new ReportParameter("ShiftDate", DAO.Helper.ConvertUnixToDateTime(shift.ShiftDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("StartTime", DAO.Helper.ConvertUnixToDateTime(shift.StartTime).ToString("HH:mm")),
                    new ReportParameter("EndTime", DAO.Helper.ConvertUnixToDateTime(shift.EndTime).ToString("HH:mm")),
                    new ReportParameter("FullName", staff.FullName.ToUpper())
                };
                this.reportViewer1.LocalReport.SetParameters(listPara);

                
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rp);
                

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
