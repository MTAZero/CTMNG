using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucAcceptQuestion : BaseModule
    {
        #region Service

        /// <summary>
        /// All Service are used to attack to databases
        /// </summary>
        private QuestionService _QuestionService;

        private SubjectService _SubjectService;
        private QuestionTypeService _QuestionTypeService;
        private TopicService _TopicService;
        private SubQuestionService _SubQuestionService;
        private AnswerService _AnswerService;
        private StaffService _StaffService;
        private StaffPositionService _StaffPositionService;
        private TopicStaffService _TopicStaffService;

        #endregion Service

        private List<QUESTION> listQuestion;
        private int CurrentQuestionIndex = 0;

        private bool GetAllQuestionNew;

        #region CurrentIdProperties

        private int CurrentSubjectId
        {
            get
            {
                try
                {
                    if (cbSubject.SelectedValue == null) return -1;
                    return int.Parse(cbSubject.SelectedValue.ToString());
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
                    if (cbTopic.SelectedValue == null) return -1;
                    return int.Parse(cbTopic.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentQuestionId { get; set; }

        private int CurrentCreateStaffId
        {
            get
            {
                try
                {
                    if (gcTask.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcTask.Rows[gcTask.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["AssignedStaffID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentTopicStaffID
        {
            get
            {
                try
                {
                    if (gcTask.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcTask.Rows[gcTask.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["TopicStaffID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        #endregion CurrentIdProperties

        public ucAcceptQuestion()
        {
            InitializeComponent();
        }

        internal override void InitModule()
        {
            _QuestionService = new QuestionService();
            _SubjectService = new SubjectService();
            _QuestionTypeService = new QuestionTypeService();
            _TopicService = new TopicService();
            _SubQuestionService = new SubQuestionService();
            _AnswerService = new AnswerService();
            _StaffService = new StaffService();
            _StaffPositionService = new StaffPositionService();
            _TopicStaffService = new TopicStaffService();

            listQuestion = new List<QUESTION>();

            cbSubject.DataSource = _SubjectService.GetAll().ToList();
            cbSubject.DisplayMember = Properties.Resources.DisplayMemberSubject;
            cbSubject.ValueMember = Properties.Resources.ValueMemberSubject;

            btnPheDuyetNV.Visible = false;
            btnPheDuyet.Visible = false;
            btnGetData.Enabled = false;
            btnNext.Enabled = false;
            btnBack.Enabled = false;

            gcTask.AutoGenerateColumns = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CurrentQuestionId = listQuestion[++CurrentQuestionIndex].QuestionID;
            InitControl(CurrentQuestionId);
            CheckEnableButton();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CurrentQuestionId = listQuestion[++CurrentQuestionIndex].QuestionID;
            InitControl(CurrentQuestionId);
            CheckEnableButton();
        }

        private void cbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            cbTopic.Text = string.Empty;
            if (CurrentSubjectId == -1) return;

            cbTopic.DataSource = _TopicService.GetAll(CurrentSubjectId).ToList();
            cbTopic.DisplayMember = Properties.Resources.DisplayMemberTopic;
            cbTopic.ValueMember = Properties.Resources.ValueMemberTopic;
        }

        private void cbTopic_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentTopicId > 0)
            {
                var data = (from ts in _TopicStaffService.GetAll(CurrentStaffId, CurrentTopicId)
                            select new
                            {
                                TopicStaffID = ts.TopicStaffID,
                                AssignedStaffID = ts.AssignedStaffID,
                                StaffName = _StaffService.GetById(ts.AssignedStaffID).FullName,
                                Description = ts.Description,
                                BeginDate = DateTimeHelpers.ConvertUnixToDateTime(ts.BeginDate).ToShortDateString(),
                                EndDate = DateTimeHelpers.ConvertUnixToDateTime(ts.EndDate).ToShortDateString(),
                                Status = GetStatusTask(ts.Status)
                            }).ToList();

                btnGetData.Enabled = CurrentTopicId > 0;
                gcTask.DataSource = data;
            }
            else gcTask.DataSource = null;
        }

        private string GetStatusTask(int status)
        {
            switch ((TaskStatusEnum)(status))
            {
                case TaskStatusEnum.Complete:
                    return Properties.Resources.Complete;

                case TaskStatusEnum.During:
                    return Properties.Resources.During;

                case TaskStatusEnum.New:
                    return Properties.Resources.New;

                case TaskStatusEnum.Over:
                    return Properties.Resources.Over;

                default:
                    return Properties.Resources.New;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            pcMain.Controls.Clear();
            CurrentQuestionIndex = 0;

            if (CurrentStaffId > 0 && CurrentTopicId > 0)
            {
                if (!GetAllQuestionNew) listQuestion = _QuestionService.GetByTopicStaff(CurrentTopicId, CurrentCreateStaffId).ToList();
                else listQuestion = _QuestionService.GetNewByTopic(CurrentTopicId).ToList();

                if (listQuestion.Count > 0)
                {
                    CheckEnableButton();
                    InitControl(listQuestion[0].QuestionID);
                    CurrentQuestionId = listQuestion[0].QuestionID;
                }
                else
                {
                    btnBack.Enabled = false;
                    btnNext.Enabled = false;
                    CurrentQuestionId = -1;
                    MessageBox.Show(Properties.Resources.NotQuestionMessage, Properties.Resources.WarningDialog);
                }
            }
            else
            {
                listQuestion = new List<QUESTION>();
            }
        }

        private void CheckEnableButton()
        {
            if (CurrentTopicStaffID > 0)
                btnPheDuyetNV.Visible =
                    _TopicStaffService.GetById(CurrentTopicStaffID).Status != (int)TaskStatusEnum.Complete;
            if (CurrentQuestionId > 0)
                btnPheDuyet.Enabled = _QuestionService.GetById(CurrentQuestionId).Status != (int)QuestionStatus.Accepted;

            btnBack.Enabled = !(CurrentQuestionIndex == 0);
            btnNext.Enabled = !(CurrentQuestionIndex == listQuestion.Count - 1);
        }

        private void InitControl(int currentQuestionId)
        {
            QUESTION question = _QuestionService.GetById(currentQuestionId);
            btnPheDuyet.Visible = question.Status != (int)QuestionStatus.Accepted;
            QUESTION_TYPES questionType = _QuestionTypeService.GetById(question.QuestionTypeID);
            List<SUBQUESTION> subQuestion = _SubQuestionService.GetAll(currentQuestionId).ToList();

            pcMain.Controls.Clear();
            ClearData();

            for (int i = questionType.NumberSubQuestion; i > 0; i--)
            {
                GroupBox grb = new GroupBox();
                grb.Dock = DockStyle.Top;
                grb.AutoSize = true;
                grb.Name = "SubQuestion" + i;
                grb.Padding = new Padding(10, 5, 10, 5);
                grb.Text = "Câu hỏi " + i;

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
                grb.AutoSize = false;
                grb.Padding = new Padding(10, 5, 10, 5);
                grb.Size = new Size(grb.Size.Width, 200);
                grb.Text = "Đoạn văn";

                RichTextBox rtb = new RichTextBox();
                rtb.ReadOnly = true;
                rtb.SelectionFont = new Font(Properties.Resources.Font, 12);
                rtb.Name = "rtbParagraph";
                rtb.MinimumSize = new Size(0, 90);
                rtb.ScrollToCaret();
                grb.Controls.Add(rtb);
                rtb.Dock = DockStyle.Fill;
                rtb.Rtf = question.QuestionContent;

                pcMain.Controls.Add(grb);
            }

            GroupBox grbInfo = new GroupBox();
            grbInfo.Dock = DockStyle.Top;
            grbInfo.AutoSize = true;
            grbInfo.Padding = new Padding(10, 5, 10, 5);
            grbInfo.Text = "Thông tin chung";

            Label lblType = new Label();
            lblType.AutoSize = true;
            lblType.Location = new Point(6, 28);
            lblType.Text = Properties.Resources.TypeQuestionName + questionType.QuestionTypeName;
            grbInfo.Controls.Add(lblType);

            Label lblLevel = new Label();
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(lblType.Location.X + lblType.Width + 50, 28);
            lblLevel.Text = Properties.Resources.Level;
            grbInfo.Controls.Add(lblLevel);

            ComboBox cboLevel = new ComboBox();
            cboLevel.Name = "cboLevel";
            cboLevel.Location = new Point(lblLevel.Location.X + lblLevel.Width + 8, 25);
            cboLevel.Size = new Size(36, 26);
            cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLevel.Items.AddRange(new string[] { "1", "2", "3", "4" });
            cboLevel.SelectedItem = question.Level.ToString();
            grbInfo.Controls.Add(cboLevel);

            pcMain.Controls.Add(grbInfo);
        }

        private void ClearData()
        {
            foreach (var textbox in pcMain.Controls.All())
            {
                textbox.Dispose();
            }
            lbThongTin.Text = "Thông Tin Ngân Hàng Câu Hỏi: Số Câu:" +
                string.Format("{0}/{1}", CurrentQuestionIndex + 1, listQuestion.Count);
        }

        private void gcTask_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (gcTask.DataSource == null) return;
            string temp = gcTask.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            if (temp == Properties.Resources.Complete)
            {
                gcTask.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
            }
            if (temp == Properties.Resources.Over)
            {
                gcTask.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            if (temp == Properties.Resources.During)
            {
                gcTask.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            if (temp == Properties.Resources.New)
            {
                gcTask.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
            }
        }

        private void btnPheDuyet_Click(object sender, EventArgs e)
        {
            if (CurrentQuestionId > 0)
            {
                QUESTION question = _QuestionService.GetById(CurrentQuestionId);
                question.Status = (int)QuestionStatus.Accepted;
                question.AcceptedStaffID = CurrentStaffId;
                question.AcceptedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);

                _QuestionService.Update(question);
                _QuestionService.Save();

                btnPheDuyet.Enabled = false;
            }
        }

        private void btnPheDuyetNV_Click(object sender, EventArgs e)
        {
            if (CurrentTopicStaffID > 0)
            {
                TOPICS_STAFFS topicStaff = _TopicStaffService.GetById(CurrentTopicStaffID);
                topicStaff.Status = (int)TaskStatusEnum.Complete;

                _TopicStaffService.Update(topicStaff);
                _TopicStaffService.Save();

                cbTopic_SelectedValueChanged(sender, e);
            }
        }

        private void ceFullQuestion_CheckedChanged(object sender, EventArgs e)
        {
            GetAllQuestionNew = ceFullQuestion.Checked;
        }
    }
}