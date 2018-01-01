using ContestManagementVer2.CSDL_Exonsytem;
using MetroFramework.Forms;
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
    public partial class FrmRpKeHoachKiThi : Form
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region constructor
        public FrmRpKeHoachKiThi()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmRpKeHoachKiThi(CONTEST ct)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            kithi = ct;
        }

        #endregion

        #region LoadForm
        private void FrmRpLichThiTheoCaThi_Load(object sender, EventArgs e)
        {
            /// Location
            int i = 1;
            var locationSource = db.LOCATIONS.Where(p => p.ContestID == kithi.ContestID && p.Status > 0)
                                                 .ToList()
                                                 .Select(p => new
                                                 {
                                                     STTLocation = i++,
                                                     LocationName = p.LocationName
                                                 })
                                                 .ToList();
            LOCATIONBindingSource.DataSource = locationSource;

            // Subject
            i = 1;
            var SubjectSource = db.SCHEDULES.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID)
                                .ToList()
                                .Select(p => new
                                {
                                    STTSubject = i++,
                                    SubjectName = db.SUBJECTS.Where(z => z.SubjectID == p.SubjectID).FirstOrDefault().SubjectName,
                                    Time = (p.TimeOfTest/60)+" phút"
                                })
                                .ToList();
            SUBJECTBindingSource.DataSource = SubjectSource;

            // Shift
            i = 1;
            var ShiftSource = db.SHIFTS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID)
                                .ToList()
                                .Select(p => new
                                {
                                    STTShift = i++,
                                    ShiftName = p.ShiftName,
                                    ShiftDate = DAO.Helper.ConvertUnixToDateTime((int) p.ShiftDate).ToString("dd/MM/yyyy"),
                                    StartTime = DAO.Helper.ConvertUnixToDateTime((int)p.StartTime).ToString("HH:mm"),
                                    EndTime = DAO.Helper.ConvertUnixToDateTime((int)p.EndTime).ToString("HH:mm")
                                })
                                .ToList();
            SHIFTBindingSource.DataSource = ShiftSource;

            // Roomtest
            i = 1;
            var RoomTestSource = (
                                 from lc in db.LOCATIONS.Where(p => p.ContestID == kithi.ContestID && p.Status > 0).ToList()
                                 from rt in db.ROOMTESTS.Where(z => z.Status > 0 && z.LocationID == lc.LocationID).ToList()
                                 select new
                                 {
                                     STTRoomTest = i++,
                                     RoomTestName = rt.RoomTestName,
                                     LocationName = lc.LocationName,
                                     MaxSeatMount = rt.MaxSeatMount
                                 })
                                 .ToList()
                                 .OrderBy(p => p.LocationName);
                                 
            ROOMTESTBindingSource.DataSource = RoomTestSource;

            // Hoi dong thi
            i = 1;
            var HoiDongThiSource = db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList()
                                   .Select(p => new
                                   {
                                       STTHoiDongThi = i++,
                                       FullName = db.STAFFS.Where(z => z.StaffID == p.StaffID).FirstOrDefault().FullName,
                                       LocationName = db.LOCATIONS.Where(z => z.LocationID == p.LocationID).FirstOrDefault().LocationName,
                                       PositionName = db.EXAMINATIONCOUNCIL_POSITIONS.Where(z => z.ExaminationCouncil_PositionID == p.ExaminationCouncil_PositionID).FirstOrDefault().ExaminationCouncil_PositionName
                                   })
                                   .ToList();
            HOIDONGTHIBindingSource.DataSource = HoiDongThiSource;


            // add parameter
            STAFF staff = db.STAFFS.Where(p=>p.StaffID == kithi.CreatedStaffID).FirstOrDefault();

            string soKeHoach = (kithi.Description != null) ? kithi.Description : " ";

            ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("SoKeHoach", soKeHoach),
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("BeginDate", DAO.Helper.ConvertUnixToDateTime((int) kithi.BeginDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("EndDate", DAO.Helper.ConvertUnixToDateTime((int) kithi.EndDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("BeginRegistration", DAO.Helper.ConvertUnixToDateTime((int) kithi.BeginRegistration).ToString("dd/MM/yyyy")),
                    new ReportParameter("EndRegistration", DAO.Helper.ConvertUnixToDateTime((int) kithi.EndRegistration).ToString("dd/MM/yyyy")),
                    new ReportParameter("CreatedQuestionStartDate", DAO.Helper.ConvertUnixToDateTime((int) kithi.CreatedQuestionStartDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("CreatedQuestionEndDate", DAO.Helper.ConvertUnixToDateTime((int) kithi.CreatedQuestionEndDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("FullName", staff.FullName.ToUpper()),
                    new ReportParameter("CreateDate", DAO.Helper.ConvertUnixToDateTime((int) kithi.CreatedDate).ToString(@"\n\g\à\y dd \t\h\á\n\g MM n\ă\m yyyy"))
                };
            this.reportViewer1.LocalReport.SetParameters(listPara);

            
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        #endregion
    }
}
