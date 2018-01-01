using EXON.Data.Services;
using EXON.Model.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Reports
{
    public partial class FrmStructTestReport : Form
    {
        private StructureService _StructureService = new StructureService();
        private ContestService _ContestService = new ContestService();
        private StructureDetailService _StructureDetailService = new StructureDetailService();
        private ScheduleService _ScheduleService = new ScheduleService();
        private SubjectService _SubjectService = new SubjectService();
        private TopicService _TopicService = new TopicService();
        private DepartmentService _DepartmentService = new DepartmentService();
        private StaffService _StaffService = new StaffService();

        private int StructTestID;

        public FrmStructTestReport(int structTestID)
        {
            InitializeComponent();
            StructTestID = structTestID;
        }

        private void FrmStructTestReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            STRUCTURE currentStruct = _StructureService.GetById(StructTestID);
            SCHEDULE currentSchedule = _ScheduleService.GetById(currentStruct.ScheduleID);
            SUBJECT currentSubject = _SubjectService.GetById(currentSchedule.SubjectID);
            CONTEST currentTest = _ContestService.GetById(currentSchedule.ContestID);
            DEPARTMENT currentDeparment = _DepartmentService.GetById(currentSubject.DepartmentID);
            STAFF currentStaff = _StaffService.GetById(currentStruct.CreatedStaffID);

            IEnumerable<TOPIC> listTopic = _TopicService.GetAll(currentSubject.SubjectID);

            List<StructDetail> listStructDetail = new List<StructDetail>();

            foreach (TOPIC t in listTopic)
            {
                IEnumerable<STRUCTURE_DETAILS> currentListStructDetail = _StructureDetailService.GetAll(currentStruct.StructureID, t.TopicID);
                StructDetail sd = new StructDetail()
                {
                    TopicName = t.TopicName,
                    Level1 = currentListStructDetail.Where(x => x.Level == 1).First().NumberQuestions.ToString(),
                    Level2 = currentListStructDetail.Where(x => x.Level == 2).First().NumberQuestions.ToString(),
                    Level3 = currentListStructDetail.Where(x => x.Level == 3).First().NumberQuestions.ToString(),
                    Level4 = currentListStructDetail.Where(x => x.Level == 4).First().NumberQuestions.ToString(),
                    Sum = currentListStructDetail.Sum(x => x.NumberQuestions).ToString()
                };
                listStructDetail.Add(sd);
            }

            StructTestBindingSource.DataSource = listStructDetail;

            ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",currentTest.ContestName.ToUpper()),
                    new ReportParameter("DepartmentName", currentDeparment.DepartmentName.ToUpper()),
                    new ReportParameter("CreatedDate",DateTime.Now.ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")),
                    new ReportParameter("FullName",currentStaff.FullName),
                    new ReportParameter("SubjectName", currentSubject.SubjectName.ToUpper()),
                };
            this.reportViewer1.LocalReport.SetParameters(listPara);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void StructTestBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }
    }

    public class StructDetail
    {
        public string TopicName { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public string Sum { get; set; }
    }
}