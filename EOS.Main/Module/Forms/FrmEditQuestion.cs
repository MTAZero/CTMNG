using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module.Forms
{
    public partial class FrmEditQuestion : MetroForm
    {
        private QuestionTypeService _QuestionTypeService;
        private QuestionService _QuestionService;
        private SubQuestionService _SubQuestionService;
        private AnswerService _AnswerService;
        private PositionService _PositionService;
        private StaffPositionService _StaffPositionService;

        private int currentQuestionId = 0;

        private QUESTION_TYPES questionType;
        private int currentTopic;
        private int currentStaffId;

        public FrmEditQuestion(int currentQuestionType, int currentTopic, int CurrentStaffId)
        {
            this.DoubleBuffered = true;
            this.currentTopic = currentTopic;
            _QuestionTypeService = new QuestionTypeService();
            _QuestionService = new QuestionService();
            _SubQuestionService = new SubQuestionService();
            _AnswerService = new AnswerService();
            _PositionService = new PositionService();
            _StaffPositionService = new StaffPositionService();

            InitializeComponent();
            InitControl(currentQuestionType);
            currentStaffId = CurrentStaffId;
        }

        private void SetTabIndex(Control control, int Index)
        {
            foreach (Control ctr in control.Controls)
            {
                ctr.TabIndex = Index;
                if (Index > 1) Index--;
                if (ctr.HasChildren)
                    SetTabIndex(ctr, Index);
            }
        }

        public FrmEditQuestion(int currentQuestionType, int currentTopic, int currentQuestionId, int CurrentStaffId)
        {
            this.DoubleBuffered = true;
            this.currentTopic = currentTopic;
            _QuestionTypeService = new QuestionTypeService();
            _QuestionService = new QuestionService();
            _SubQuestionService = new SubQuestionService();
            _AnswerService = new AnswerService();

            InitializeComponent();
            InitControl(currentQuestionType);
            this.currentQuestionId = currentQuestionId;
            this.currentStaffId = CurrentStaffId;
        }

        private void InitControl(int currentQuestionType)
        {
            questionType = _QuestionTypeService.GetById(currentQuestionType);
            pcMain.Controls.Clear();

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
                    rtb.TextChanged += EditValueChanged;
                    rtb.Dock = DockStyle.Fill;
                    rtb.Name = "rtbQ" + i + "Ans" + j + "Content";
                    rtb.ScrollToCaret();
                    pnl.Controls.Add(rtb);

                    if (questionType.IsSingleChoice)
                    {
                        RadioButton rdoCorrect = new RadioButton();
                        rdoCorrect.Dock = DockStyle.Left;
                        rdoCorrect.AutoSize = true;
                        rdoCorrect.Name = "rdoQ" + i + "Correct" + j;
                        rdoCorrect.Text = "Câu trả lời " + j + ".";
                        if (j == 1)
                            rdoCorrect.Checked = true;
                        rdoCorrect.CheckedChanged += RdoCorrect_CheckedChanged;
                        pnl.Controls.Add(rdoCorrect);
                    }
                    else
                    {
                        CheckBox chkCorrect = new CheckBox();
                        chkCorrect.Dock = DockStyle.Left;
                        chkCorrect.AutoSize = true;
                        chkCorrect.Name = "chkQ" + i + "Correct" + j;
                        chkCorrect.Text = "Câu trả lời " + j + ".";
                        pnl.Controls.Add(chkCorrect);
                    }

                    grb.Controls.Add(pnl);
                }
                if (questionType.IsQuestionContent)
                {
                    RichTextBox rtb = new RichTextBox();
                    rtb.TextChanged += EditValueChanged;
                    rtb.Dock = DockStyle.Top;
                    rtb.Name = "rtbQ" + i + "Content";
                    rtb.Size = new Size(0, 52);
                    rtb.ScrollToCaret();
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
                rtb.TextChanged += EditValueChanged;
                rtb.Dock = DockStyle.Top;
                rtb.Name = "rtbParagraph";
                rtb.MinimumSize = new Size(0, 78);
                rtb.ScrollToCaret();
                grb.Controls.Add(rtb);

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
            cboLevel.SelectedItem = "1";
            grbInfo.Controls.Add(cboLevel);

            pcMain.Controls.Add(grbInfo);

            ClearData();
        }

        private void RdoCorrect_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                foreach (Control ctr1 in rb.Parent.Parent.Controls)
                {
                    foreach (Control ctr2 in ctr1.Controls)
                        if (ctr2.GetType() == typeof(RadioButton))
                        {
                            if ((RadioButton)ctr2 == rb)
                            {
                                continue;
                            }
                            ((RadioButton)ctr2).Checked = false;
                        }
                }
            }
        }

        private void EditValueChanged(object sender, System.EventArgs e)
        {
            foreach (var textbox in pcMain.Controls.All().OfType<RichTextBox>())
            {
                if (string.IsNullOrEmpty(textbox.Text))
                {
                    btnUpdate.Enabled = false;
                    return;
                }
            }
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                QUESTION newQuestion = new QUESTION();
                ComboBox cbo = (ComboBox)pcMain.Controls.Find("cboLevel", true).FirstOrDefault();
                newQuestion.Level = int.Parse(cbo.SelectedItem.ToString());

                if (questionType.IsParagraph)
                {
                    RichTextBox rtb = (RichTextBox)pcMain.Controls.Find("rtbParagraph", true).FirstOrDefault();
                    newQuestion.QuestionContent = rtb.Rtf;
                }
                newQuestion.QuestionFormat = (int)QuestionFormat.RTF;
                newQuestion.Status = CheckCNBM(currentStaffId) ? (int)QuestionStatus.Accepted : (int)QuestionStatus.New;
                if (newQuestion.Status == (int)QuestionStatus.Accepted)
                {
                    newQuestion.AcceptedStaffID = currentStaffId;
                    newQuestion.AcceptedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                }

                newQuestion.CreatedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                newQuestion.QuestionTypeID = questionType.QuestionTypeID;
                newQuestion.TopicID = currentTopic;
                newQuestion.CreatedStaffID = currentStaffId;

                if (currentQuestionId == 0) _QuestionService.Add(newQuestion);
                else
                {
                    newQuestion.QuestionID = currentQuestionId;
                    _QuestionService.Update(newQuestion);
                }
                _QuestionService.Save();

                for (int i = 0; i < questionType.NumberSubQuestion; i++)
                {
                    SUBQUESTION listSubQuestion = new SUBQUESTION();
                    listSubQuestion.QuestionID = newQuestion.QuestionID;

                    if (questionType.IsQuestionContent)
                    {
                        RichTextBox rtb = (RichTextBox)pcMain.Controls.Find("rtbQ" + (i + 1) + "Content", true).FirstOrDefault();
                        listSubQuestion.SubQuestionContent = rtb.Rtf;
                    }
                    if (currentQuestionId != 0)
                    {
                        Label lbl = (Label)pcMain.Controls.Find("lblQ" + (i + 1) + "ID", true).FirstOrDefault();
                        listSubQuestion.SubQuestionID = int.Parse(lbl.Text);
                        _SubQuestionService.Update(listSubQuestion);
                    }
                    else _SubQuestionService.Add(listSubQuestion);
                    _SubQuestionService.Save();

                    for (int j = 0; j < questionType.NumberAnswer; j++)
                    {
                        ANSWER listAnswer = new ANSWER();
                        listAnswer.SubQuestionID = listSubQuestion.SubQuestionID;

                        RichTextBox rtb = (RichTextBox)pcMain.Controls.Find("rtbQ" + (i + 1) + "Ans" + (j + 1) + "Content", true).FirstOrDefault();
                        listAnswer.AnswerContent = rtb.Rtf;

                        if (questionType.IsSingleChoice)
                        {
                            RadioButton rdo = (RadioButton)pcMain.Controls.Find("rdoQ" + (i + 1) + "Correct" + (j + 1), true).FirstOrDefault();
                            listAnswer.IsCorrect = (rdo == null ? false : rdo.Checked);
                        }
                        else
                        {
                            CheckBox chkC = (CheckBox)pcMain.Controls.Find("chkQ" + (i + 1) + "Correct" + (j + 1), true).FirstOrDefault();
                            listAnswer.IsCorrect = (chkC == null ? false : chkC.Checked);
                        }

                        if (currentQuestionId != 0)
                        {
                            Label lblA = (Label)pcMain.Controls.Find("lblQ" + (i + 1) + "Ans" + (j + 1) + "ID", true).FirstOrDefault();
                            listAnswer.AnswerID = int.Parse(lblA.Text);
                            _AnswerService.Update(listAnswer);
                        }
                        else _AnswerService.Add(listAnswer);
                        _AnswerService.Save();
                    }
                }
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.Error);
                return;
            }
        }

        private bool CheckCNBM(int currentStaffId)
        {
            var data = from sp in _StaffPositionService.GetAll(currentStaffId)
                       from p in _PositionService.GetAll().Where(x => x.PositionCode == PositionEnum.CNBM.ToString())
                       where sp.PositionID == p.PositionID
                       select sp.PositionID;
            return data.Count() != 0;
        }

        private void ClearData()
        {
            int i = 0;
            foreach (var textbox in pcMain.Controls.All().OfType<RichTextBox>())
            {
                textbox.TabIndex = i++;
                textbox.Text = string.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}