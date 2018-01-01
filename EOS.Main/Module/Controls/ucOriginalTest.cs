using EXON.Common;
using EXON.Data.Services;
using EXON.Main.Core;
using EXON.Main.Helper;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucOriginalTest : BaseModule
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
        private TestService _TestService;
        private TestDetailService _TestDetailService;
        private SubQuestionService _SubQuestionService;
        private AnswerService _AnswerService;
        private QuestionTypeService _QuestionTypeService;

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

        private int CurrentOriginalTestId
        {
            get
            {
                try
                {
                    if (gcOriginalTest.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcOriginalTest.Rows[gcOriginalTest.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["OriginalTestID"].Value.ToString());
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

        public ucOriginalTest()
        {
            InitializeService();
            InitializeComponent();
            gcOriginalTest.AutoGenerateColumns = false;
            gcShift.AutoGenerateColumns = false;
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
            _TestService = new TestService();
            _TestDetailService = new TestDetailService();
            _SubQuestionService = new SubQuestionService();
            _AnswerService = new AnswerService();
            _QuestionTypeService = new QuestionTypeService();
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
            var data = from c in _ContestService.GetAllAccepted().ToList()
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
            btnPheDuyet.Enabled = false;
            btnXoaDeThiGoc.Enabled = false;
            btnXemDe.Enabled = false;
            btnXemDe.Location = btnTaoDeThiGoc.Location;
        }

        private void btnTaoDeThiGoc_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Visible /*&& CheckTime(CurrentContestID)*/)
            {
                CreateOriginalTest(CurrentSubjectId, CurrentScheduleId, CurrentContestID);
                InitDataOriginalTest();
            }
        }

        private bool CheckTime(int currentContestID)
        {
            CONTEST currentContest = _ContestService.GetById(currentContestID);
            DateTime begin = DateTimeHelpers.ConvertUnixToDateTime(currentContest.CreatedQuestionStartDate);
            DateTime end = DateTimeHelpers.ConvertUnixToDateTime(currentContest.CreatedQuestionEndDate);
            if (begin <= SystemTimeService.Now && end >= SystemTimeService.Now)
            {
                return true;
            }
            else
            {
                MessageBox.Show(Properties.Resources.NotDuringTestMessage, Properties.Resources.WarningDialog);
                return false;
            }
        }

        private void btnXemDeThi(object sender, EventArgs e)
        {
            ORIGINAL_TESTS test = _OriginalTestService.GetById(CurrentOriginalTestId);

            List<ORIGINAL_TEST_DETAILS> listOriginalTest = _OriginalTestDetailService.GetAll(test.OriginalTestID).ToList();
            List<QUESTION> listQuestion = (from otd in listOriginalTest
                                           from q in _QuestionService.GetAll().ToList()
                                           where otd.QuestionID == q.QuestionID
                                           select new QUESTION()
                                           {
                                               QuestionID = q.QuestionID,
                                               Level = q.Level,
                                               QuestionTypeID = q.QuestionTypeID,
                                               QuestionContent = q.QuestionContent,
                                               TopicID = q.TopicID
                                           }).ToList();

            ClearData();
            InitControl4Panel(listQuestion);
        }

        private bool CheckNumOriginalTest(int SubjectId, int ScheduleId, int ContestId, int NumContestant)
        {
            if (SubjectId > 0 && ScheduleId > 0)
            {
                int minNumQuestion = int.MaxValue;
                int minOriginalTest = 1;

                List<TOPIC> listTopic = _TopicService.GetAll(SubjectId).ToList();
                List<QUESTION> listOriginalTest = new List<QUESTION>();
                List<QUESTION_TYPES> listQuestionType = _QuestionTypeService.GetAll().ToList();

                STRUCTURE structure = _StructureService.GetByScheduleId(ScheduleId);
                if (structure == null)
                {
                    MessageBox.Show(Properties.Resources.NotStructureMessage, Properties.Resources.WarningDialog);
                    return false;
                }

                for (int i = 0; i < listTopic.Count; i++)
                {
                    List<STRUCTURE_DETAILS> listStructureDetail =
                    _StructureDetailService.GetAll(_StructureService
                    .GetByScheduleId(ScheduleId).StructureID, listTopic[i].TopicID)
                    .ToList();

                    for (int j = 0; j < listStructureDetail.Count; j++)
                    {
                        if (listStructureDetail[j].NumberQuestions > 1 && minNumQuestion > listStructureDetail[j].NumberQuestions)
                            minNumQuestion = listStructureDetail[j].NumberQuestions;
                    }
                    if (minNumQuestion == int.MaxValue) minNumQuestion = 1;
                }
                if (listTopic.Count != 0 && minNumQuestion != int.MaxValue)
                {
                    if (minNumQuestion != 1)
                    {
                        while (true)
                        {
                            bool isOK = MathHelper.GetPermutations<int>
                                (Enumerable.Range(1, minOriginalTest * minNumQuestion), minNumQuestion).Count() > NumContestant;
                            if (isOK) break;
                            else minOriginalTest++;

                        }
                    }
                    else
                    {
                        int getByContestant = (int)Math.Ceiling((decimal)(0.1 * NumContestant));
                        minOriginalTest = getByContestant < 3 ? getByContestant : 3;
                    }

                    if (minOriginalTest > (int)numericUpDown1.Value)
                    {
                        MessageBox.Show(string.Format("Bạn Cần Tạo Ít Nhất {0} Đề Thi Gốc", minOriginalTest),
                            Properties.Resources.WarningDialog);
                        numericUpDown1.Value = minOriginalTest;
                    }
                }
            }
            return true;
        }

        private bool CreateOriginalTest(int SubjectId, int ScheduleId, int ContestId)
        {
            if (SubjectId > 0 && ScheduleId > 0)
            {
                if (CheckNumOriginalTest(CurrentSubjectId, CurrentScheduleId, CurrentContestID, CurrentNumContestant))
                {
                    int NumOfTest = (int)numericUpDown1.Value;

                    List<List<QUESTION>> listOriginalTest = new List<List<QUESTION>>();
                    for (int i = 0; i < NumOfTest; i++)
                        listOriginalTest.Add(new List<QUESTION>());

                    List<TOPIC> listTopic = _TopicService.GetAll(SubjectId).ToList();
                    List<QUESTION_TYPES> listQuestionType = _QuestionTypeService.GetAll().ToList();

                    bool IsEnable = true;
                    string messageLog = string.Empty;

                    for (int i = 0; i < listTopic.Count; i++)
                    {
                        List<STRUCTURE_DETAILS> listStructureDetail =
                        _StructureDetailService.GetAll(_StructureService
                        .GetByScheduleId(ScheduleId).StructureID, listTopic[i].TopicID)
                        .ToList();

                        for (int j = 0; j < listStructureDetail.Count; j++)
                        {
                            if (listStructureDetail[j].NumberQuestions == 0) continue;
                            List<QUESTION> listQuestion = _QuestionService
                                .GetByTopicLevel(listTopic[i].TopicID, listStructureDetail[j].Level)
                                .ToList();

                            int SumQuestion = 0;
                            List<QuestionOfType> listQuestionOfType = new List<QuestionOfType>();
                            foreach (QUESTION_TYPES qt in _QuestionTypeService.GetAll())
                            {
                                QuestionOfType questionOfType = new QuestionOfType();
                                questionOfType.NumOfSubQestion = qt.NumberSubQuestion;
                                questionOfType.QuestionTypeID = qt.QuestionTypeID;

                                foreach (QUESTION q in listQuestion)
                                {
                                    if (q.QuestionTypeID == qt.QuestionTypeID)
                                    {
                                        questionOfType.NumOfQuestion++;
                                        SumQuestion += qt.NumberSubQuestion;
                                    }
                                }
                                if (questionOfType.NumOfQuestion != 0)
                                    listQuestionOfType.Add(questionOfType);
                            }

                            if (SumQuestion < listStructureDetail[j].NumberQuestions * NumOfTest)
                            {
                                messageLog += string.Format(@"Cần Bổ Sung Ít Nhất {0} Câu Hỏi Level {1}
                                    Chủ Đề {2} Môn {3} Vào Ngân Hàng Câu Hỏi\n",
                                        listStructureDetail[j].NumberQuestions * NumOfTest - listQuestion.Count,
                                        listStructureDetail[j].Level,
                                        listTopic[i].TopicName,
                                        _SubjectService.GetById(listTopic[i].SubjectID).SubjectName)
                                        .Replace("\n", Environment.NewLine);
                                IsEnable = false;
                                if (!IsEnable) continue;
                            }

                            try
                            {
                                //Xoa tron de tao ngau nhien
                                listQuestionOfType = RandomQuestionOfType(listQuestionOfType);
                                listQuestionOfType = GetListNumberQuestionGet(listQuestionOfType, listStructureDetail[j].NumberQuestions, NumOfTest);

                                foreach (QuestionOfType qt in listQuestionOfType)
                                {
                                    if (qt.NumOfQestionGet == 0) continue;

                                    List<QUESTION> listFilterQuestion = listQuestion.Where(x => x.QuestionTypeID == qt.QuestionTypeID).ToList();
                                    if (listFilterQuestion.Count < qt.NumOfQestionGet * NumOfTest)
                                    {
                                        messageLog += string.Format(@"Cần Bổ Sung Ít Nhất {0} Câu Hỏi Level {1}
                                    Chủ Đề {2} Môn {3} \nLoại {4} \nVào Ngân Hàng Câu Hỏi\n",
                                                qt.NumOfQestionGet * NumOfTest - listFilterQuestion.Count,
                                                listStructureDetail[j].Level,
                                                listTopic[i].TopicName,
                                                _SubjectService.GetById(listTopic[i].SubjectID).SubjectName,
                                                _QuestionTypeService.GetById(qt.QuestionTypeID).Description)
                                                .Replace("\n", Environment.NewLine);

                                        IsEnable = false;
                                    }
                                    if (!IsEnable) continue;


                                    if (qt.NumOfQestionGet == 1)
                                    {
                                        while (listFilterQuestion.Count < qt.NumOfQestionGet * NumOfTest)
                                            listFilterQuestion.AddRange(listFilterQuestion);
                                    }
                                    List<QUESTION> listQuestionRandom =
                                        _QuestionService.GetRandomList(listFilterQuestion,
                                        qt.NumOfQestionGet * NumOfTest);

                                    for (int t = 0; t < NumOfTest; t++)
                                    {
                                        listOriginalTest[t].AddRange(listQuestionRandom
                                            .GetRange(t * qt.NumOfQestionGet, qt.NumOfQestionGet));
                                    }
                                }
                            }
                            catch
                            {
                                MessageBox.Show(Properties.Resources.NotEnoughQuestionMessage, Properties.Resources.WarningDialog);
                                MessageBox.Show(messageLog, Properties.Resources.WarningDialog);
                                return false;
                            }
                        }
                    }
                    if (!IsEnable)
                    {
                        MessageBox.Show(messageLog, Properties.Resources.WarningDialog);
                        return false;
                    }

                    #region Save to DataBase

                    try
                    {
                        foreach (List<QUESTION> originalQuestion in listOriginalTest)
                        {
                            ORIGINAL_TESTS originalTest = new ORIGINAL_TESTS()
                            {
                                CreateDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                                SubjectID = SubjectId,
                                ContestID = ContestId,
                                Status = (int)OriginalTestStatus.New
                            };
                            _OriginalTestService.Add(originalTest);
                            _OriginalTestService.Save();

                            for (int i = 0; i < originalQuestion.Count; i++)
                            {
                                ORIGINAL_TEST_DETAILS detail = new ORIGINAL_TEST_DETAILS()
                                {
                                    NumberIndex = i,
                                    OriginalTestID = originalTest.OriginalTestID,
                                    QuestionID = originalQuestion[i].QuestionID,
                                    Status = 1
                                };
                                _OriginalTestDetailService.Add(detail);
                            }
                            _OriginalTestDetailService.Save();
                        }
                        MessageBox.Show(Properties.Resources.OriginalTestCreateSuccess, Properties.Resources.Success);
                        btnXoaDeThiGoc.Enabled = true;
                        btnTaoDeThiGoc.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Properties.Resources.Error);
                        return false;
                    }

                    return true;

                    #endregion Save to DataBase
                }
                else
                {
                    MessageBox.Show(Properties.Resources.Error, Properties.Resources.Error);
                    return false;
                }
            }
            else return false;
        }

        private List<QuestionOfType> RandomQuestionOfType(List<QuestionOfType> listQuestionOfType)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
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
                    if (q.NumOfSubQestion == 1)
                    {
                        q.NumOfQestionGet = RealSumQuestionNeed;
                        RealSumQuestionNeed = 0;
                    }
                }
            }
            return listQuestionOfType;
        }

        private void InitDataOriginalTest()
        {
            List<ORIGINAL_TESTS> test = _OriginalTestService
                .GetByNewContest2Subject(CurrentContestID, CurrentSubjectId)
                .ToList();

            var data = (from t in test
                        select new
                        {
                            OriginalTestID = t.OriginalTestID,
                            CreateDate = DateTimeHelpers.ConvertUnixToDateTime(t.CreateDate),
                            AcceptDate = DateTimeHelpers.ConvertUnixToDateTime(t.AcceptDate ?? 0),
                            OriginalTestName = Properties.Resources.bbiOriginalTestDescription,
                            Status = CheckStatusOrginalTest((OriginalTestStatus)t.Status)
                        }).ToList();

            if (data.Count == 0)
            {
                btnTaoDeThiGoc.Visible = true;
                btnXemDe.Visible = false;
            }
            else
            {
                btnTaoDeThiGoc.Visible = false;
                btnXemDe.Visible = true;
                numericUpDown1.Visible = false;
            }
            gcOriginalTest.DataSource = data;
        }

        private string CheckStatusOrginalTest(OriginalTestStatus status)
        {
            switch (status)
            {
                case OriginalTestStatus.New:
                    return Properties.Resources.New;

                case OriginalTestStatus.Accepted:
                    return Properties.Resources.Accepted;

                default:
                    return Properties.Resources.New;
            }
        }

        private void gcShift_SelectionChanged(object sender, EventArgs e)
        {
            InitDataOriginalTest();
            btnTaoDeThiGoc.Enabled = CurrentContestID > 0 && CurrentOriginalTestId < 0;
            numericUpDown1.Visible = btnTaoDeThiGoc.Enabled;
            numericUpDown1.Value = numericUpDown1.Minimum;
        }

        private void gleKiThi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentContestID > 0)
            {
                List<SHIFT> listShift = _ShiftService.GetAll(CurrentContestID).ToList();
                List<DIVISION_SHIFTS> listDivisionShift = _DivisionShiftService.GetAll().ToList();
                List<CONTESTANTS_SHIFTS> listContantShift = _ContestantShiftService.GetAll().ToList();
                List<SCHEDULE> listSchedule = _ScheduleService.GetAllByContest(CurrentContestID).ToList();
                List<SUBJECT> listSubject = _SubjectService.GetAll().ToList();
                var listShiftJoin = (from s in listShift
                                     from cs in listContantShift
                                     from sc in listSchedule
                                     from sb in listSubject
                                     from ds in listDivisionShift
                                     where ds.ShiftID == s.ShiftID
                                     where ds.DivisionShiftID == cs.ShiftID
                                     where cs.ScheduleID == sc.ScheduleID
                                     where sb.SubjectID == sc.SubjectID
                                     select new
                                     {
                                         SubjectName = sb.SubjectName + " (" + sc.TimeOfTest / 60 + ")",
                                         SubjectCode = sb.SubjectCode,
                                         SubjectID = sc.SubjectID,
                                         ScheduleID = sc.ScheduleID,
                                         NumContestant = GetNumContestant(sc.SubjectID, CurrentContestID)
                                     }).Distinct().ToList();

                gcShift.DataSource = listShiftJoin;
            }
        }

        private int GetNumContestant(int subjectID, int currentContestID)
        {
            int ScheduleID = _ScheduleService.GetByContestAndSubject(currentContestID, subjectID).ScheduleID;
            return _ContestantShiftService.GetAllBySchedule(ScheduleID).Count();
        }

        private void btnXoaDeThiGoc_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(Properties.Resources.YesNoMessage,
                Properties.Resources.WarningDialog,
                MessageBoxButtons.OK))
            {
                _OriginalTestDetailService.DeleteAllByOriginalTest(CurrentOriginalTestId);
                _OriginalTestDetailService.Save();

                _OriginalTestService.Delete(CurrentOriginalTestId);
                _OriginalTestService.Save();

                InitDataOriginalTest();
            }
        }

        private void gcOriginalTest_SelectionChanged(object sender, EventArgs e)
        {
            pcMain.Controls.Clear();
            ClearData();
            if (CurrentOriginalTestId <= 0 || gcOriginalTest.RowCount == 0) return;

            ORIGINAL_TESTS test = _OriginalTestService.GetById(CurrentOriginalTestId);
            btnXemDe.Enabled = test != null;
            btnPheDuyet.Enabled = (test != null) && test.Status != (int)OriginalTestStatus.Accepted;
        }

        private void InitControl4Panel(List<QUESTION> listQuestion)
        {
            int Index = 1;
            SplashForm.ShowSplashScreen();
            foreach (QUESTION question in listQuestion)
            {
                QUESTION_TYPES questionType = _QuestionTypeService.GetById(question.QuestionTypeID);
                List<SUBQUESTION> subQuestion = _SubQuestionService.GetAll(question.QuestionID).ToList();

                for (int i = questionType.NumberSubQuestion; i > 0; i--)
                {
                    GroupBox grb = new GroupBox();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Name = "SubQuestion" + i;
                    grb.Padding = new Padding(10, 5, 10, 5);
                    grb.Text = "Câu hỏi " + Index++;

                    Label lblQ = new Label();
                    lblQ.Visible = false;
                    lblQ.Name = "lblQ" + i + "ID";
                    grb.Controls.Add(lblQ);

                    List<ANSWER> listAnswer = _AnswerService
                        .GetAll(subQuestion[i - 1].SubQuestionID)
                        .ToList();
                    for (int j = questionType.NumberAnswer; j > 0; j--)
                    {
                        Panel pnl = new Panel();
                        pnl.Dock = DockStyle.Top;
                        pnl.Size = new Size(0, 59);
                        pnl.Padding = new Padding(5, 5, 0, 5);

                        Label lbl = new Label();
                        lbl.Visible = false;
                        lbl.Name = "lblQ" + i + "Ans" + j + "ID";
                        pnl.Controls.Add(lbl);

                        RichTextBox rtb = new RichTextBox();
                        rtb.ReadOnly = true;
                        rtb.SelectionFont = new Font(Properties.Resources.Font, 11);
                        rtb.Dock = DockStyle.Fill;
                        rtb.Name = "rtbQ" + i + "Ans" + j + "Content";
                        rtb.ScrollToCaret();
                        rtb.Rtf = listAnswer[j - 1].AnswerContent;

                        pnl.Controls.Add(rtb);

                        if (questionType.IsSingleChoice)
                        {
                            RadioButton rdoCorrect = new RadioButton();
                            rdoCorrect.Dock = DockStyle.Left;
                            rdoCorrect.AutoSize = true;
                            rdoCorrect.Name = "rdoQ" + i + "Correct" + j;
                            rdoCorrect.Text = "Câu trả lời " + j + ".";
                            rdoCorrect.Checked = listAnswer[j - 1].IsCorrect;

                            pnl.Controls.Add(rdoCorrect);
                        }
                        else
                        {
                            CheckBox chkCorrect = new CheckBox();
                            chkCorrect.Dock = DockStyle.Left;
                            chkCorrect.AutoSize = true;
                            chkCorrect.Name = "chkQ" + i + "Correct" + j;
                            chkCorrect.Text = "Câu trả lời " + j + ".";
                            chkCorrect.Checked = listAnswer[j - 1].IsCorrect;

                            pnl.Controls.Add(chkCorrect);
                        }

                        grb.Controls.Add(pnl);
                    }
                    if (questionType.IsQuestionContent)
                    {
                        RichTextBox rtb = new RichTextBox();
                        rtb.ReadOnly = true;
                        rtb.Dock = DockStyle.Top;
                        rtb.SelectionFont = new Font(Properties.Resources.Font, 11);
                        rtb.Name = "rtbQ" + i + "Content";
                        rtb.Size = new Size(0, 52);
                        rtb.ScrollToCaret();
                        rtb.Rtf = subQuestion[i - 1].SubQuestionContent;

                        grb.Controls.Add(rtb);
                    }

                    pcMain.Controls.Add(grb);
                }
                if (questionType.IsParagraph)
                {
                    GroupBox grb = new GroupBox();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Padding = new Padding(10, 5, 10, 5);
                    grb.Text = "Đoạn văn";

                    RichTextBox rtb = new RichTextBox();
                    rtb.ReadOnly = true;
                    rtb.SelectionFont = new Font(Properties.Resources.Font, 11);
                    rtb.Dock = DockStyle.Bottom;
                    rtb.Name = "rtbParagraph";
                    rtb.MinimumSize = new Size(0, 78);
                    rtb.ScrollToCaret();
                    rtb.Rtf = question.QuestionContent;
                    grb.Controls.Add(rtb);

                    pcMain.Controls.Add(grb);
                }
            }
            SplashForm.CloseForm();
        }

        private void ClearData()
        {
            foreach (var textbox in pcMain.Controls.All())
            {
                textbox.Dispose();
            }
        }

        private void gcOriginalTest_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (gcOriginalTest.DataSource == null || gcOriginalTest.RowCount == 0) return;
            string temp = gcOriginalTest.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            if (temp == Properties.Resources.New)
            {
                gcOriginalTest.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            if (temp == Properties.Resources.Accepted)
            {
                gcOriginalTest.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
            }
        }

        private void btnPheDuyet_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(Properties.Resources.YesNoMessage,
                Properties.Resources.WarningDialog,
                MessageBoxButtons.OK))
            {
                ORIGINAL_TESTS test = _OriginalTestService.GetById(CurrentOriginalTestId);
                if (test != null)
                {
                    test.AcceptDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                    test.Status = (int)OriginalTestStatus.Accepted;
                    _OriginalTestService.Update(test);
                    _OriginalTestService.Save();
                }
            }
            InitDataOriginalTest();
            btnPheDuyet.Enabled = false;
        }

        private void btnPrintTest_Click(object sender, EventArgs e)
        {

        }
    }
}