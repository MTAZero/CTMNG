using EXON.Common;
using EXON.Data.Services;
using EXON.Main.Core;
using EXON.Main.Helper;
using EXON.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucTest : BaseModule
    {
        #region Service

        private ContestService _ContestService;
        private ShiftService _ShiftService;
        private ScheduleService _ScheduleService;
        private ContestantShiftService _ContestantShiftService;
        private SubjectService _SubjectService;
        private StructureDetailService _StructureDetailService;
        private StructureService _StructureService;
        private TopicService _TopicService;
        private QuestionService _QuestionService;
        private OriginalTestService _OriginalTestService;
        private OriginalTestDetailService _OriginalTestDetailService;
        private BagOfTestService _BagOfTestService;
        private DivisionShiftService _DivisionShiftService;
        private QuestionTypeService _QuestionTypeService;
        private TestService _TestServiceMain;

        #endregion Service

        private int CurrentContestID
        {
            get
            {
                if (gleKiThi.SelectedValue == null) return -1;
                try
                {
                    return int.Parse(gleKiThi.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentTestID
        {
            get
            {
                try
                {
                    if (gcOriginalTest.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcOriginalTest.Rows[gcOriginalTest.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["TestID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentSubjectId
        {
            get
            {
                try
                {
                    if (gcShift.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcShift.Rows[gcShift.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["SubjectID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentNumContestant
        {
            get
            {
                try
                {
                    if (gcShift.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcShift.Rows[gcShift.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["NumContestant"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentScheduleId
        {
            get
            {
                try
                {
                    if (gcShift.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcShift.Rows[gcShift.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["ScheduleID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentShiftId
        {
            get
            {
                try
                {
                    if (gcShift.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcShift.Rows[gcShift.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["ShiftID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        public ucTest()
        {
            InitializeService();
            InitializeComponent();
        }

        private void InitializeService()
        {
            _ContestService = new ContestService();
            _ShiftService = new ShiftService();
            _ScheduleService = new ScheduleService();
            _ContestantShiftService = new ContestantShiftService();
            _SubjectService = new SubjectService();
            _StructureDetailService = new StructureDetailService();
            _StructureService = new StructureService();
            _TopicService = new TopicService();
            _QuestionService = new QuestionService();
            _OriginalTestService = new OriginalTestService();
            _OriginalTestDetailService = new OriginalTestDetailService();
            _BagOfTestService = new BagOfTestService();
            _DivisionShiftService = new DivisionShiftService();
            _QuestionTypeService = new QuestionTypeService();
            _TestServiceMain = new TestService();
        }

        internal override void InitModule()
        {
            InitData4GleKiThi();
            InitEnableButton();
        }

        private void InitData4GleKiThi()
        {
#if DEBUG
            var data = from c in _ContestService.GetAll().ToList()
                       select new
                       {
                           ContestID = c.ContestID,
                           ContestName = c.ContestName,
                           BeginDate = c.BeginDate.HasValue ? DateTimeHelpers.ConvertUnixToDateTime(c.BeginDate.Value) : DateTime.MinValue,
                           EndDate = c.EndDate.HasValue ? DateTimeHelpers.ConvertUnixToDateTime(c.EndDate.Value) : DateTime.MinValue
                       };
#else
            var data  = from c in _ContestService.GetAllAccepted().ToList()
                       select new
                       {
                           ContestID = c.ContestID,
                           ContestName = c.ContestName,
                           BeginDate = DateTimeHelpers.ConvertUnixToDateTime(c.BeginDate.Value),
                           EndDate = DateTimeHelpers.ConvertUnixToDateTime(c.EndDate.Value)
                       };
#endif
            gleKiThi.DataSource = data.ToList();
            gleKiThi.ValueMember = "ContestID";
            gleKiThi.DisplayMember = "ContestName";
        }

        private void InitEnableButton()
        {
            btnTaoDeThiGoc.Enabled = false;
        }

        private void gleKiThi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentContestID > 0)
            {
                List<SHIFT> listShift = _ShiftService.GetAll(CurrentContestID).ToList();
                List<DIVISION_SHIFTS> listDivisionShift = new List<DIVISION_SHIFTS>();
                for (int i = 0; i < listShift.Count; i++)
                    listDivisionShift.AddRange(_DivisionShiftService.GetByShift(listShift[i].ShiftID));

                List<CONTESTANTS_SHIFTS> listContantShift = new List<CONTESTANTS_SHIFTS>();
                for (int i = 0; i < listDivisionShift.Count; i++)
                    listContantShift.AddRange(_ContestantShiftService.GetAllByShift(listDivisionShift[i].DivisionShiftID));


                List<SCHEDULE> listSchedule = _ScheduleService.GetAllByContest(CurrentContestID).ToList();
                List<SUBJECT> listSubject = _SubjectService.GetAll().ToList();
                var listShiftJoin = (from s in listShift
                                     from cs in listContantShift
                                     from sc in listSchedule
                                     from sb in listSubject
                                     from ds in listDivisionShift
                                     where s.ShiftID==ds.ShiftID
                                     where ds.DivisionShiftID==cs.ShiftID
                                     where cs.ScheduleID == sc.ScheduleID
                                     where sb.SubjectID == sc.SubjectID
                                     select new
                                     {
                                         ShiftID = s.ShiftID,
                                         ShiftName = s.ShiftName,
                                         ShiftDate= DateTimeHelpers.ConvertUnixToDateTime(s.ShiftDate).ToShortDateString(),
                                         SubjectName = sb.SubjectName + " (" + sc.TimeOfTest / 60 + ")",
                                         SubjectCode = sb.SubjectCode,
                                         SubjectID = sc.SubjectID,
                                         ScheduleID = sc.ScheduleID,
                                         NumContestant = GetNumContestant(sb.SubjectID, CurrentContestID, s.ShiftID)
                                     }).Distinct().ToList();
                
                gcShift.DataSource = listShiftJoin;
                btnTaoDeThiGoc.Enabled = CurrentShiftId > 0 && CurrentTestID <= 0;
            }
        }

        private int GetNumContestant(int subjectID, int currentContestID, int shiftId)
        {
            int ScheduleID = _ScheduleService.GetByContestAndSubject(currentContestID, subjectID).ScheduleID;
            var data = from ds in _DivisionShiftService.GetByShift(shiftId)
                       from cs in _ContestantShiftService.GetAllBySchedule(ScheduleID)
                       where ds.DivisionShiftID == cs.ShiftID
                       select cs.ContestantID;
            return data.Count();
        }

        private void gcShift_SelectionChanged(object sender, EventArgs e)
        {
            InitDataTest();
            btnTaoDeThiGoc.Enabled = CurrentShiftId > 0 && CurrentTestID <= 0;
        }

        private void InitDataTest()
        {
            var data = (from ds in _DivisionShiftService.GetByShift(CurrentShiftId)
                        from bot in _BagOfTestService.GetAll()
                        from t in _TestServiceMain.GetAllBySubject(CurrentSubjectId)
                        where bot.BagOfTestID == t.BagOfTestID
                        where ds.DivisionShiftID == bot.DivisionShiftID
                        select new
                        {
                            TestName = "Đề Thi" + t.TestID,
                            TestID = t.TestID,
                            TestDate = DateTimeHelpers.ConvertUnixToDateTime(t.TestDate).ToShortDateString()
                        }).ToList();
            gcOriginalTest.DataSource = data;
        }

        private void btnTaoDeThiGoc_Click(object sender, EventArgs e)
        {
            if (CurrentContestID > 0 && CurrentSubjectId > 0)
            {
                try
                {
                    SplashForm.ShowSplashScreen();

                    #region Make Test for Shift

                    IEnumerable<ORIGINAL_TESTS> listOriginalTest = _OriginalTestService
                        .GetByContest2Subject(CurrentContestID, CurrentSubjectId);

                    if (listOriginalTest.Count() == 0)
                    {
                        SplashForm.CloseForm();
                        MessageBox.Show(Properties.Resources.NotOriginalTestMessage.Replace("\n", Environment.NewLine), Properties.Resources.WarningDialog);
                        return;
                    }
                    List<QUESTION> listQuestionTest = new List<QUESTION>();
                    for (int i = 0; i < listOriginalTest.Count(); i++)
                    {
                        IEnumerable<ORIGINAL_TEST_DETAILS> listTestDetail = _OriginalTestDetailService.GetAll(listOriginalTest.ToList()[i].OriginalTestID);
                        for (int j = 0; j < listTestDetail.Count(); j++)
                        {
                            listQuestionTest.Add(_QuestionService.GetById(listTestDetail.ToList()[j].QuestionID));
                        }
                    }

                    List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectId).ToList();
                    List<QUESTION_TYPES> listQuestionType = _QuestionTypeService.GetAll().ToList();

                    int numberOfTest = (int)Math.Round((double)CurrentNumContestant * DataResources.ScaleNumOfTest);

                    List<List<QUESTION>> listTestQuestion = new List<List<QUESTION>>();
                    for (int i = 0; i < numberOfTest; i++)
                        listTestQuestion.Add(new List<QUESTION>());

                    for (int i = 0; i < listTopic.Count; i++)
                    {
                        List<STRUCTURE_DETAILS> listStructureDetail =
                        _StructureDetailService.GetAll(_StructureService
                        .GetByScheduleId(CurrentScheduleId).StructureID, listTopic[i].TopicID)
                        .ToList();

                        for (int j = 0; j < listStructureDetail.Count; j++)
                        {
                            if (listStructureDetail[j].NumberQuestions == 0) continue;
                            List<QUESTION> listQuestion4Topic = listQuestionTest
                                .Where(x => x.TopicID == listTopic[i].TopicID && x.Level == listStructureDetail[j].Level)
                                .ToList();

                            for (int k = 0; k < numberOfTest; k++)
                            {
                                List<QuestionOfType> listQuestionOfType = new List<QuestionOfType>();
                                foreach (QUESTION_TYPES qt in _QuestionTypeService.GetAll())
                                {
                                    QuestionOfType questionOfType = new QuestionOfType();
                                    questionOfType.NumOfSubQestion = qt.NumberSubQuestion;
                                    questionOfType.QuestionTypeID = qt.QuestionTypeID;

                                    foreach (QUESTION q in listQuestion4Topic)
                                    {
                                        if (q.QuestionTypeID == qt.QuestionTypeID)
                                        {
                                            questionOfType.NumOfQuestion++;
                                        }
                                    }
                                    if (questionOfType.NumOfQuestion != 0)
                                        listQuestionOfType.Add(questionOfType);
                                }
                                listQuestionOfType = RandomQuestionOfType(listQuestionOfType);
                                listQuestionOfType = GetListNumberQuestionGet(listQuestionOfType, listStructureDetail[j].NumberQuestions, numberOfTest);

                                foreach (QuestionOfType qt in listQuestionOfType)
                                {
                                    if (qt.NumOfQestionGet == 0) continue;

                                    List<QUESTION> listFilterQuestion = listQuestion4Topic.Where(x => x.QuestionTypeID == qt.QuestionTypeID).ToList();
                                    List<QUESTION> listQuestionRandom =
                                            _QuestionService.GetRandomList(listFilterQuestion,
                                            qt.NumOfQestionGet);
                                    foreach (QUESTION q in listQuestionRandom)
                                        q.QuestionFormat = (int)(listStructureDetail[j].Score * 1000);

                                    listTestQuestion[k].AddRange(listQuestionRandom);
                                }
                            }
                        }
                    }

                    #endregion Make Test for Shift

                    #region Make Test for Division Shift From Test Above

                    var listContestant = (from ds in _DivisionShiftService.GetByShift(CurrentShiftId)
                                          from cs in _ContestantShiftService
                                          .GetAllBySchedule(_ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectId).ScheduleID)
                                          where ds.DivisionShiftID == cs.ShiftID
                                          select new
                                          {
                                              DivisionShiftID = ds.DivisionShiftID,
                                              ContestantID = cs.ContestantID,
                                              RoomTestID = ds.RoomTestID,
                                              Status = ds.Status
                                          }).ToList();

                    List<DIVISION_SHIFTS> listRoomShift = _DivisionShiftService.GetByShift(CurrentShiftId).ToList();

                    int currentDivisionShiftId = listContestant.First().DivisionShiftID;
                    for (int r = 0; r < listRoomShift.Count; r++)
                    {
                        int notByDividionShift = (int)Math.Round((double)listContestant
                            .Where(x => x.RoomTestID == listRoomShift[r].RoomTestID)
                            .Count() * DataResources.ScaleNumOfTest);

                        BAGOFTEST bagOfTest = _BagOfTestService.GetAllByDivisionShift(listRoomShift[r].DivisionShiftID).FirstOrDefault();
                        if (bagOfTest == null)
                        {
                            bagOfTest = new BAGOFTEST()
                            {
                                DivisionShiftID = listRoomShift[r].DivisionShiftID,
                                NumberOfTest = notByDividionShift,
                                Status = 1
                            };
                            _BagOfTestService.Add(bagOfTest);
                        }
                        else
                        {
                            bagOfTest.NumberOfTest += numberOfTest;
                            _BagOfTestService.Update(bagOfTest);
                        }
                        _BagOfTestService.Save();

                        Parallel.ForEach(DataHelper.GetRandomByNumber(listTestQuestion, notByDividionShift), item =>
                         {
                             TestService _TestService = new TestService();
                             TestDetailService _TestDetailService = new TestDetailService();

                             TEST test = new TEST()
                             {
                                 BagOfTestID = bagOfTest.BagOfTestID,
                                 TestDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                                 SubjectID = CurrentSubjectId
                             };
                             _TestService.Add(test);
                             _TestService.Save();

                             List<QUESTION> listRandomQuestion = _QuestionService.GetRandomList(item, item.Count);
                             for (int j = 0; j < listRandomQuestion.Count; j++)
                             {
                                 TEST_DETAILS testDetail = new TEST_DETAILS()
                                 {
                                     NumberIndex = j,
                                     TestID = test.TestID,
                                     Score = (double)listRandomQuestion[j].QuestionFormat / 1000,
                                     QuestionID = listRandomQuestion[j].QuestionID,
                                     RandomAnswer = ConvertToJsonRandomAnswer(listRandomQuestion[j].QuestionID)
                                 };

                                 _TestDetailService.Add(testDetail);
                             }
                             _TestDetailService.Save();
                         });
                    }

                    #endregion Make Test for Division Shift From Test Above

                    #region update status contest

                    CONTEST contest = _ContestService.GetById(CurrentContestID);
                    contest.Status = (int)ContestStatus.DuringHaveTest;
                    _ContestService.Update(contest);
                    _ContestService.Save();

                    #endregion update status contest
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    SplashForm.CloseForm();
                    MessageBox.Show(Properties.Resources.Success, Properties.Resources.Notification);
                    InitDataTest();
                    btnTaoDeThiGoc.Enabled = false;
                }
            }
        }

        private List<QuestionOfType> RandomQuestionOfType(List<QuestionOfType> listQuestionOfType)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            if (listQuestionOfType.Count == 0) return new List<QuestionOfType>();
            int randomIndex = r.Next(0, listQuestionOfType.Count);
            var temp = listQuestionOfType[randomIndex];
            listQuestionOfType[randomIndex] = listQuestionOfType[0];
            listQuestionOfType[0] = temp;

            return listQuestionOfType;
        }

        private List<QuestionOfType> GetListNumberQuestionGet(List<QuestionOfType> listQuestionOfType, int sumQuestionNeed, int NumOfTest)
        {
            if (listQuestionOfType.Count == 1)
            {
                listQuestionOfType[0].NumOfQestionGet = sumQuestionNeed / listQuestionOfType[0].NumOfSubQestion;
                return listQuestionOfType;
            }
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int RealSumQuestionNeed = sumQuestionNeed;
            foreach (QuestionOfType q in listQuestionOfType)
            {
                if (q.NumOfSubQestion != 1 && RealSumQuestionNeed != 0 && RealSumQuestionNeed >= q.NumOfSubQestion)
                {
                    int max = (int)(q.NumOfQuestion / NumOfTest);
                    do
                    {
                        if (max == 0) break;
                        q.NumOfQestionGet = r.Next(1, max);
                    } while (RealSumQuestionNeed < q.NumOfQestionGet * q.NumOfSubQestion);
                    RealSumQuestionNeed -= q.NumOfQestionGet * q.NumOfSubQestion;
                }
                else
                {
                    q.NumOfQestionGet = RealSumQuestionNeed;
                    RealSumQuestionNeed = 0;
                }
            }
            return listQuestionOfType;
        }

        public string ConvertToJsonRandomAnswer(int QuestionID)
        {
            AnswerService _AnswerService = new AnswerService();
            SubQuestionService _SubQuestionService = new SubQuestionService();

            List<SUBQUESTION> listSubQuestion = _SubQuestionService.GetAll(QuestionID).ToList();
            List<SubQuestion> listSubQuestion4Json = new List<SubQuestion>();

            for (int i = 0; i < listSubQuestion.Count; i++)
            {
                List<ANSWER> listAnswer = _AnswerService.GetAll(listSubQuestion[i].SubQuestionID).ToList();
                List<ANSWER> listRandom = _AnswerService.GetRandomList(listAnswer, listAnswer.Count);

                List<int> listAnswerID = new List<int>();
                foreach (ANSWER a in listRandom)
                    listAnswerID.Add(a.AnswerID);

                listSubQuestion4Json.Add(new SubQuestion()
                {
                    SubQuestionID = listSubQuestion[i].SubQuestionID,
                    ListAnswerID = listAnswerID
                });
            }
            return JsonConvert.SerializeObject(listSubQuestion4Json);
        }
    }
}