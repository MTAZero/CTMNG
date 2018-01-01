using EXON.Common;
using EXON.Data.Services;
using EXON.Main.Core;
using EXON.Main.Module.Report;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucStructureTest : BaseModule
    {
        private ContestService _ContestService;
        private ScheduleService _ScheduleService;
        private SubjectService _SubjectService;
        private TopicService _TopicService;
        private StructureService _StructureService;
        private StructureDetailService _StructureDetailService;

        private List<NumericUpDown> listLevel;
        private DataTable dataGrid;

        private int TotalNumOfQuestion;
        private double TotalScore;
        private ucTotalStructureDetail totalStructureTest;

        public override string ModuleName { get { return Properties.Resources.StructureTestName; } }

        private int CurrentSubjectId
        {
            get
            {
                if (gcSubject.CurrentCell.RowIndex < 0) return -1;
                DataGridViewRow data = gcSubject.Rows[gcSubject.CurrentCell.RowIndex];
                return int.Parse(data.Cells["SubjectID"].Value.ToString());
            }
        }

        private int CurrentContestId
        {
            get
            {
                try
                {
                    if (gleKiThi.SelectedValue == null) return -1;
                    return int.Parse(gleKiThi.SelectedValue.ToString());
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
                    if (gcSubject.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcSubject.Rows[gcSubject.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["ScheduleID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentTopicId
        {
            get
            {
                try
                {
                    if (gcTopic.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcTopic.Rows[gcTopic.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["TopicID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        public ucStructureTest()
        {
            _ContestService = new ContestService();
            _ScheduleService = new ScheduleService();
            _SubjectService = new SubjectService();
            _TopicService = new TopicService();
            _StructureService = new StructureService();
            _StructureDetailService = new StructureDetailService();

            InitializeComponent();
            InitLabelText();
            InitData();

            btnUpdate.Enabled = false;
            btnReportStructTest.Enabled = false;
        }

        internal override void InitModule()
        {
            base.InitModule();
            InitDataTable4GcTopic();

            gcSubject.AutoGenerateColumns = false;
            gcTopic.AutoGenerateColumns = false;
        }

        private void InitData()
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

        private void InitLabelText()
        {
            lbLevel1.Text = Properties.Resources.Level1;
            lbLevel2.Text = Properties.Resources.Level2;
            lbLevel3.Text = Properties.Resources.Level3;
            lbLevel4.Text = Properties.Resources.Level4;

            NumberQuestions1.HeaderText = Properties.Resources.Level1;
            NumberQuestions2.HeaderText = Properties.Resources.Level2;
            NumberQuestions3.HeaderText = Properties.Resources.Level3;
            NumberQuestions4.HeaderText = Properties.Resources.Level4;

            listLevel = this.Controls.All().OrderBy(x => x.Name).OfType<NumericUpDown>().ToList();
            foreach (NumericUpDown n in listLevel) n.ValueChanged += NumericValueChanged;
        }

        private void gleKiThi_SelectedValueChanged(object sender, EventArgs e)
        {
            gcSubject.DataSource = null;
            if (CurrentContestId <= 0) return;

            var data = from sc in _ScheduleService.GetAllByContest(CurrentContestId)
                       from sb in _SubjectService.GetAll()
                       where sc.SubjectID == sb.SubjectID
                       select new
                       {
                           SubjectID = sb.SubjectID,
                           SubjectName = sb.SubjectName,
                           SubjectCode = sb.SubjectCode,
                           TimeOfTest = sc.TimeOfTest / 60,
                           ScheduleID = sc.ScheduleID
                       };
            gcSubject.DataSource = data.ToList();
            ClearData();
        }

        private void gcSubject_SelectionChanged(object sender, EventArgs e)
        {
            SplashForm.ShowSplashScreen();
            ClearData();
            if (CurrentSubjectId > 0)
            {
                GetData4GcTopic(CurrentSubjectId);
                GetData4Panel(CurrentSubjectId);
                if (CurrentTopicId < 0) btnUpdate.Enabled = false;
                btnReportStructTest.Enabled = pnMain.Controls.Count != 0;
            }
            SplashForm.CloseForm();
        }

        private void GetData4Panel(int currentSubjectId)
        {
            pnMain.Controls.Clear();
            pnTotal.Controls.Clear();
            TotalNumOfQuestion = 0;
            TotalScore = 0;

            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleId);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    List<TOPIC> listTopic = _TopicService.GetAll(currentSubjectId).ToList();
                    for (int t = listTopic.Count - 1; t >= 0; t--)
                    {
                        ucStructDetail structDetail = new ucStructDetail(structure, listTopic[t]);
                        pnMain.Controls.Add(structDetail);
                        TotalNumOfQuestion += structDetail.TotalNumQuestion;
                        TotalScore += structDetail.TotalScore;
                    }
                }
                pnMain.Refresh();
            }
            totalStructureTest = new ucTotalStructureDetail(TotalNumOfQuestion, TotalScore);
            totalStructureTest.Location = new System.Drawing.Point((int)(pnMain.Location.X * 0.9), (int)(pnMain.Location.Y * 0.5));
            totalStructureTest.Dock = DockStyle.Fill;
            totalStructureTest.Visible = true;
            pnTotal.Controls.Add(totalStructureTest);
        }

        private void CanculateTotal()
        {
            TotalNumOfQuestion = 0;
            TotalScore = 0;

            foreach (ucStructDetail c in pnMain.Controls)
            {
                TotalNumOfQuestion += c.TotalNumQuestion;
                TotalScore += c.TotalScore;
            }
            totalStructureTest.SetValue(TotalNumOfQuestion, TotalScore);
        }

        private void InitDataTable4GcTopic()
        {
            dataGrid = new DataTable();

            dataGrid = new DataTable();
            dataGrid.Columns.Add(new DataColumn()
            {
                ColumnName = "TopicID",
                DataType = typeof(int)
            });
            dataGrid.Columns.Add(new DataColumn()
            {
                ColumnName = "TopicName",
                DataType = typeof(string)
            });
            dataGrid.Columns.Add(new DataColumn()
            {
                ColumnName = "Description",
                DataType = typeof(string)
            });
            dataGrid.Columns.Add(new DataColumn()
            {
                ColumnName = "NumberQuestions1",
                DataType = typeof(string)
            });
            dataGrid.Columns.Add(new DataColumn()
            {
                ColumnName = "NumberQuestions2",
                DataType = typeof(string)
            });
            dataGrid.Columns.Add(new DataColumn()
            {
                ColumnName = "NumberQuestions3",
                DataType = typeof(string)
            });
            dataGrid.Columns.Add(new DataColumn()
            {
                ColumnName = "NumberQuestions4",
                DataType = typeof(string)
            });
        }

        private void GetData4GcTopic(int SubjectId)
        {
            dataGrid.Rows.Clear();
            List<TOPIC> listTopic = _TopicService.GetAll(SubjectId).ToList();

            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleId);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    for (int i = 0; i < listTopic.Count; i++)
                    {
                        List<STRUCTURE_DETAILS> listStructureDetail =
                        _StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID).ToList();

                        DataRow rowTopic = dataGrid.NewRow();
                        rowTopic["TopicID"] = listTopic[i].TopicID;
                        rowTopic["TopicName"] = listTopic[i].TopicName;
                        rowTopic["Description"] = listTopic[i].Description;

                        foreach (STRUCTURE_DETAILS sd in listStructureDetail)
                        {
                            string colName = "NumberQuestions" + sd.Level.ToString();
                            rowTopic[colName] = sd.NumberQuestions;
                        }
                        dataGrid.Rows.Add(rowTopic);
                    }
                }
                else
                {
                    gcTopic.DataSource = _TopicService.GetAll(CurrentSubjectId).ToList();
                    return;
                }
            }
            gcTopic.DataSource = dataGrid;
        }

        private void gcTopic_SelectionChanged(object sender, EventArgs e)
        {
            ClearData();
            InitData4Numeric();
            ChangeColorBackgroundStructureDetail();

            if (CurrentTopicId > 0)
            {
                btnUpdate.Enabled = true;
                btnReportStructTest.Enabled = true;
            }
        }

        private void ChangeColorBackgroundStructureDetail()
        {
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleId);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    foreach (ucStructDetail sd in pnMain.Controls)
                    {
                        if (sd.CheckCorrectStructureDetail(structure.StructureID, CurrentTopicId))
                        {
                            sd.ChangeColor(true);
                            pnMain.ScrollControlIntoView(sd);
                        }

                        else sd.ChangeColor(false);
                    }
                }
            }
        }

        private void InitData4Numeric()
        {
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleId);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    List<STRUCTURE_DETAILS> listStructureDetail =
                        _StructureDetailService.GetAll(structure.StructureID, CurrentTopicId).ToList();

                    foreach (STRUCTURE_DETAILS sd in listStructureDetail)
                    {
                        listLevel[2 * sd.Level - 2].Value = sd.NumberQuestions;
                        listLevel[2 * sd.Level - 1].Value = (decimal)sd.Score;
                    }

                    deNgayTao.Value = DateTimeHelpers.ConvertUnixToDateTime(structure.CreatedDate);
                }
                else deNgayTao.Value = SystemTimeService.Now;
            }
            else
            {
                MessageBox.Show(Properties.Resources.NotScheduleMessage, Properties.Resources.WarningDialog);
                btnUpdate.Enabled = false;
            }
        }

        private void ClearData()
        {
            foreach (NumericUpDown c in this.Controls.All().OfType<NumericUpDown>())
                c.Value = 0;
        }

        private void NumericValueChanged(object sender, EventArgs e)
        {
            decimal SumScore = 0;
            int NumQuestion = 0;

            for (int i = 0; i < listLevel.Count; i++)
                if (i % 2 == 0) NumQuestion += (int)listLevel[i].Value;
                else SumScore += listLevel[i].Value * listLevel[i - 1].Value;

            lbNumQuestion.Text = "Số Câu: " + NumQuestion.ToString();
            lbSumScore.Text = "Tổng Điểm: " + SumScore.ToString("00.00");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleId);
                if (schedule != null)
                {
                    STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                    if (structure != null)
                    {
                        List<STRUCTURE_DETAILS> listStructureDetail =
                            _StructureDetailService.GetAll(structure.StructureID, CurrentTopicId).ToList();

                        if (listStructureDetail.Count > 0)
                        {
                            foreach (STRUCTURE_DETAILS sd in listStructureDetail)
                            {
                                sd.NumberQuestions = (int)listLevel[2 * sd.Level - 2].Value;
                                sd.Score = (double)listLevel[2 * sd.Level - 1].Value;

                                if (!CheckQuestionEnough(CurrentTopicId, sd.Level)) { }
                                _StructureDetailService.Update(sd);
                            }
                            _StructureDetailService.Save();

                            structure.CreatedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                            _StructureService.Update(structure);
                            _StructureService.Save();
                        }
                        else
                        {
                            for (int i = 0; i < listLevel.Count; i += 2)
                            {
                                STRUCTURE_DETAILS sd = new STRUCTURE_DETAILS()
                                {
                                    Level = i / 2 + 1,
                                    NumberQuestions = (int)listLevel[i].Value,
                                    Score = (double)listLevel[i + 1].Value,
                                    StructureID = structure.StructureID,
                                    TopicID = CurrentTopicId,
                                    Status = 1
                                };
                                _StructureDetailService.Add(sd);
                            }
                            _StructureDetailService.Save();
                            ucStructDetail structDetail = new ucStructDetail(structure, _TopicService.GetById(CurrentTopicId));
                            pnMain.Controls.Add(structDetail);
                        }

                    }
                    else
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

                        for (int i = 0; i < listLevel.Count; i += 2)
                        {
                            STRUCTURE_DETAILS sd = new STRUCTURE_DETAILS()
                            {
                                Level = i / 2 + 1,
                                NumberQuestions = (int)listLevel[i].Value,
                                Score = (double)listLevel[i + 1].Value,
                                StructureID = structure.StructureID,
                                TopicID = CurrentTopicId,
                                Status = 1
                            };
                            _StructureDetailService.Add(sd);                           
                        }
                        ucStructDetail structDetail = new ucStructDetail(structure, _TopicService.GetById(CurrentTopicId));
                        pnMain.Controls.Add(structDetail);
                        _StructureDetailService.Save();
                    }
                    UpdateStructureDetailView(structure.StructureID, CurrentTopicId);
                }
                btnReportStructTest.Enabled = true;
                CanculateTotal();
                MessageBox.Show(Properties.Resources.Success, Properties.Resources.Insert);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.Error);
            }
            //GetData4GcTopic(CurrentSubjectId);
        }

        private bool CheckQuestionEnough(int currentTopicId, int level)
        {

            return false;
        }

        private void UpdateStructureDetailView(int structureID, int topicID)
        {
            foreach (ucStructDetail sd in pnMain.Controls)
            {
                if (sd.CheckCorrectStructureDetail(structureID, topicID))
                {
                    sd.Refesh();
                    break;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReportStructTest_Click(object sender, EventArgs e)
        {
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleId);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if(structure!=null)
                {
                    FrmStructTestReport temp = new FrmStructTestReport(structure.StructureID);
                    temp.ShowDialog();
                }               
            }
        }
    }
}