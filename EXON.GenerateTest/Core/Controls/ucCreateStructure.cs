using EXON.Common;
using EXON.Data.Services;
using EXON.GenerateTest.Core.Common;
using EXON.GenerateTest.Core.Models;
using EXON.GenerateTest.Core.Reports;
using EXON.GenerateTest.Core.Tags;
using EXON.Model.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucCreateStructure : BaseModule
    {
        private ContestService _ContestService;
        private ScheduleService _ScheduleService;
        private SubjectService _SubjectService;
        private TopicService _TopicService;
        private StructureService _StructureService;
        private StructureDetailService _StructureDetailService;

        private int TotalNumOfQuestion;
        private double TotalScore;

        private int CurrentScheduleID
        {
            get
            {
                try
                {
                    if (StaticResource.ContestID <= 0) return -1;
                    return _ScheduleService.GetByContestAndSubject(StaticResource.ContestID, CurrentSubjectID).ScheduleID;
                }
                catch
                {
                    return -1;
                }
            }
        }

        private int CurrentSubjectID { get { return StaticResource.SubjectID; } }

        private int CurrentTopicID
        {
            get
            {
                try
                {
                    if (gcStructTest.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcStructTest.Rows[gcStructTest.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["TopicID"].Value.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return -1;
                }
            }
        }

        public ucCreateStructure()
        {
            InitializeComponent();

            _ContestService = new ContestService();
            _ScheduleService = new ScheduleService();
            _SubjectService = new SubjectService();
            _TopicService = new TopicService();
            _StructureService = new StructureService();
            _StructureDetailService = new StructureDetailService();
        }

        public override void InitModule()
        {
            base.InitModule();
            Initdata4GcStructTest();
            InitControl4Panel();
        }

        private void InitControl4Panel()
        {
            SplashScreenManager.ShowSplashScreen();

            pnMain.Controls.Clear();
            List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectID).ToList();
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                for (int i = listTopic.Count - 1; i >= 0; i--)
                {
                    ucDisplayStructure detail = new ucDisplayStructure(structure, listTopic[i]);
                    detail.UpdateStatus += UpdateGridView;
                    pnMain.Controls.Add(detail);
                }
                CanculateTotal();
            }

            SplashScreenManager.CloseForm();
        }

        public override void Refresh()
        {
            base.Refresh();
            UpdateGridView();
            InitControl4Panel();
        }

        private void UpdateGridView()
        {
            _StructureDetailService = new StructureDetailService();
            Initdata4GcStructTest();
            CanculateTotal();
        }

        private void CanculateTotal()
        {
            TotalNumOfQuestion = 0;
            TotalScore = 0;

            foreach (Control c in pnMain.Controls)
            {
                if (c.GetType() == typeof(ucDisplayStructure))
                {
                    TotalNumOfQuestion += (c as ucDisplayStructure).TotalNumQuestion;
                    TotalScore += (c as ucDisplayStructure).TotalScore;
                }
            }

            lbTotalQuestion.Text = string.Format("Tổng số câu hỏi: {0}", TotalNumOfQuestion);
            lbTotalScore.Text = string.Format("Tổng số điểm: {0}", TotalScore);
        }

        private void Initdata4GcStructTest()
        {
            List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectID).ToList();
            lbTotalTopic.Text = string.Format("Số Chủ Đề {0}", listTopic.Count);
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure == null)
                {
                    structure = new STRUCTURE()
                    {
                        CreatedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                        ScheduleID = schedule.ScheduleID,
                        CreatedStaffID = CurrentStaffId,
                        Status = 1
                    };
                    _StructureService.Add(structure);
                    _StructureService.Save();

                    foreach (TOPIC t in listTopic)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            STRUCTURE_DETAILS sd = new STRUCTURE_DETAILS()
                            {
                                Level = i,
                                NumberQuestions = 0,
                                Score = 1,
                                StructureID = structure.StructureID,
                                TopicID = t.TopicID,
                                Status = 1
                            };
                            _StructureDetailService.Add(sd);
                        }
                        _StructureDetailService.Save();
                    }
                }

                List<StructureDetailViewModel> listStructureDetailViewModel = new List<StructureDetailViewModel>();
                for (int i = 0; i < listTopic.Count; i++)
                {
                    List<STRUCTURE_DETAILS> listStructureDetail =
                        _StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID).ToList();

                    StructureDetailViewModel model = new StructureDetailViewModel
                    {
                        TopicID = listTopic[i].TopicID,
                        TopicName = listTopic[i].TopicName,
                        Level1 = listStructureDetail[0].NumberQuestions,
                        Level2 = listStructureDetail[1].NumberQuestions,
                        Level3 = listStructureDetail[2].NumberQuestions,
                        Level4 = listStructureDetail[3].NumberQuestions
                    };
                    listStructureDetailViewModel.Add(model);
                }
                gcStructTest.DataSource = listStructureDetailViewModel;
            }
        }

        public override string ModuleName
        {
            get
            {
                return Properties.Resources.StructureTestName;
            }
        }

        protected internal override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResource.CreateStruct:
                    MetroMessageBox.Show(this, "Vui lòng nhập cấu trúc theo form bên phải",
                        Properties.Resources.Notification,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;

                case TagResource.UpdateStruct:
                    MetroMessageBox.Show(this, "Vui lòng sửa cấu trúc bằng cách nhấn Sửa ở form bên phải",
                        Properties.Resources.Notification,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;

                case TagResource.ExportStructToDoc:
                    CreateReportStruct();
                    break;
            }
        }

        private void CreateReportStruct()
        {
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    FrmStructTestReport temp = new FrmStructTestReport(structure.StructureID);
                    temp.ShowDialog();
                }
            }
            else MetroMessageBox.Show(this, "Chưa Có Cấu Trúc Đề",
                       Properties.Resources.Notification,
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
        }

        private void gcStructTest_SelectionChanged(object sender, System.EventArgs e)
        {

            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    foreach (ucDisplayStructure sd in pnMain.Controls)
                    {
                        if (sd.CheckCorrectStructureDetail(structure.StructureID, CurrentTopicID))
                        {
                            //sd.ChangeColor(true);
                            pnMain.ScrollControlIntoView(sd);
                        }

                        else sd.ChangeColor(false);
                    }
                }
            }
        }
    }
}