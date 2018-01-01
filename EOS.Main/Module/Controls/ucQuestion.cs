using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DW.RtfWriter;
using EXON.Common;
using EXON.Data.Services;
using EXON.Main.Module.Forms;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace EXON.Main.Module.Controls
{
    public partial class ucQuestion : BaseModule
    {
        private QuestionService _QuestionService;
        private SubjectService _SubjectService;
        private QuestionTypeService _QuestionTypeService;
        private TopicService _TopicService;
        private SubQuestionService _SubQuestionService;
        private AnswerService _AnswerService;
        private StaffService _StaffService;
        private StaffPositionService _StaffPositionService;
        private PositionService _PositionService;

        private List<QUESTION> listQuestion;
        private int CurrentQuestionIndex = 0;

        public override string ModuleName { get { return Properties.Resources.QuestionName; } }

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

        private int CurrentQuestionTypeId
        {
            get
            {
                try
                {
                    if (cbQuestionType.SelectedValue == null) return -1;
                    return int.Parse(cbQuestionType.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentQuestionId { get; set; }

        public ucQuestion()
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
            listQuestion = new List<QUESTION>();
            _PositionService = new PositionService();
            _StaffPositionService = new StaffPositionService();

            InitComboBox();
            EnableDataButton(!string.IsNullOrEmpty(cbTopic.Text) && !string.IsNullOrEmpty(cbQuestionType.Text));
        }

        private void EnableDataButton(bool isEnable)
        {
            btnGetData.Enabled = isEnable;
            btnNhapTuWord.Enabled = false;
            btnAddNewQuestion.Enabled = false;
            btnDeleteQuestion.Enabled = false;
            btnNext.Enabled = false;
            btnBack.Enabled = false;

            ClearData();
            pcMain.Controls.Clear();
        }

        private void InitComboBox()
        {
            cbSubject.DataSource = _SubjectService.GetAllByDepartment(_StaffService.GetById(CurrentStaffId).DepartmentID).ToList();
            cbSubject.DisplayMember = Properties.Resources.DisplayMemberSubject;
            cbSubject.ValueMember = Properties.Resources.ValueMemberSubject;

            cbQuestionType.DataSource = _QuestionTypeService.GetAll().ToList();
            cbQuestionType.DisplayMember = Properties.Resources.DisplayMemberQuestionType;
            cbQuestionType.ValueMember = Properties.Resources.ValueMemberQuestionType;
        }

        private void btnGetData_Click(object sender, System.EventArgs e)
        {
            btnAddNewQuestion.Enabled = true;
            btnDeleteQuestion.Enabled = true;
            btnNhapTuWord.Enabled = true;
            CurrentQuestionIndex = 0;

            if (CurrentQuestionTypeId > 0 && CurrentTopicId > 0)
            {
                listQuestion = _QuestionService.GetByTopicType(CurrentTopicId, CurrentQuestionTypeId)
                    .ToList();
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
                    MessageBox.Show(Properties.Resources.NotQuestionMessage, Properties.Resources.WarningDialog);
                }
            }
            else
            {
                listQuestion = new List<QUESTION>();
            }
        }

        private void InitControl(int currentQuestionId)
        {
            QUESTION question = _QuestionService.GetById(currentQuestionId);
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
                    rtb.SelectionFont = new System.Drawing.Font(Properties.Resources.Font, 11);
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
                        System.Windows.Forms.CheckBox chkCorrect = new System.Windows.Forms.CheckBox();
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
                    rtb.SelectionFont = new System.Drawing.Font(Properties.Resources.Font, 11);
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
                rtb.SelectionFont = new System.Drawing.Font(Properties.Resources.Font, 12);
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

        private void cbSubject_SelectedValueChanged(object sender, System.EventArgs e)
        {
            cbTopic.Text = string.Empty;
            if (CurrentSubjectId == -1) return;

            cbTopic.DataSource = _TopicService.GetAll(CurrentSubjectId).ToList();
            cbTopic.DisplayMember = Properties.Resources.DisplayMemberTopic;
            cbTopic.ValueMember = Properties.Resources.ValueMemberTopic;

            EnableDataButton(!string.IsNullOrEmpty(cbTopic.Text) && !string.IsNullOrEmpty(cbQuestionType.Text));
        }

        private void btnNhapTuWord_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Multiselect = false,
                Title = btnNhapTuWord.Text,
                Filter = "Word .docx Files (*.docx)|*.docx;"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                QUESTION_TYPES currentQuestionType = _QuestionTypeService.GetById(CurrentQuestionTypeId);
                if (!currentQuestionType.IsQuiz) return;

                WordprocessingDocument doc = WordprocessingDocument.Open(ofd.FileName, false);

                string body_table = "DocumentFormat.OpenXml.Wordprocessing.Table";
                string body_paragraph = "DocumentFormat.OpenXml.Wordprocessing.Paragraph";
                string table_row = "DocumentFormat.OpenXml.Wordprocessing.TableRow";
                string table_cell = "DocumentFormat.OpenXml.Wordprocessing.TableCell";
                string run = "DocumentFormat.OpenXml.Wordprocessing.Run";
                string run_properties = "DocumentFormat.OpenXml.Wordprocessing.RunProperties";
                string text = "DocumentFormat.OpenXml.Wordprocessing.Text";
                string bold = "DocumentFormat.OpenXml.Wordprocessing.Bold";
                string italic = "DocumentFormat.OpenXml.Wordprocessing.Italic";
                string underline = "DocumentFormat.OpenXml.Wordprocessing.Underline";

                Body body = doc.MainDocumentPart.Document.Body;

                string paragrap = string.Empty;

                #region getparagrap
                foreach (var b in body)
                {
                    string body_type = b.ToString();

                    if (body_type == body_paragraph)
                    {
                        foreach (var r in b)
                        {
                            if (r.ToString() == run)
                            {
                                string paragraph_properties = string.Empty;
                                string paragraph_content = string.Empty;
                                foreach (var rv in r)
                                {
                                    if (rv.ToString() == run_properties)
                                    {
                                        foreach (var tp in rv)
                                        {
                                            paragraph_properties += tp.ToString() + '\n';
                                        }
                                    }
                                    if (rv.ToString() == text)
                                    {
                                        paragraph_content += rv.InnerText + '\n';
                                    }
                                }

                                if (paragraph_content.Trim() == string.Empty)
                                    continue;

                                var rtfDoc = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.TraditionalChinese);
                                var times = rtfDoc.createFont("Times New Roman");

                                RtfParagraph par = rtfDoc.addParagraph(); ;
                                par.DefaultCharFormat.Font = times;
                                par.setText(paragraph_content);

                                RtfCharFormat fmt = par.addCharFormat(0, paragraph_content.Length - 1);
                                fmt.FontSize = 18;
                                if (paragraph_properties.Contains(bold)) fmt.FontStyle.addStyle(FontStyleFlag.Bold);
                                fmt.Font = times;

                                paragrap = rtfDoc.render();

                            }
                        }
                    }
                    #endregion
                    if (body_type == body_table)
                    {
                        QUESTION question = new QUESTION()
                        {
                            QuestionTypeID = currentQuestionType.QuestionTypeID,
                            CreatedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                            Level = 1,
                            QuestionFormat = (int)QuestionFormat.RTF,
                            TopicID = CurrentTopicId,
                            CreatedStaffID = CurrentStaffId,
                            Status = CheckCNBM(CurrentStaffId) ? (int)QuestionStatus.Accepted : (int)QuestionStatus.New
                        };
                        if (question.Status == (int)QuestionStatus.Accepted)
                        {
                            question.AcceptedStaffID = CurrentStaffId;
                            question.AcceptedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                        }

                        //Cau hoi khong co tieu de nhu lua chon dap an dung ...
                        if (currentQuestionType.IsParagraph && !currentQuestionType.IsQuestionContent)
                            question.QuestionContent = paragrap;
                        _QuestionService.Add(question);
                        //_QuestionService.Save();

                        List<string> listRowData = new List<string>();

                        foreach (var tr in b)
                        {
                            if (tr.ToString() == table_row)
                            {                                
                                foreach (var tc in tr)
                                {
                                    if (tc.ToString() == table_cell)
                                    {
                                        foreach (var p in tc)
                                        {
                                            if (p.InnerText.Count() <= 2) continue;                                          

                                            if (p.ToString() == body_paragraph)
                                            {
                                                var rtfDoc = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.TraditionalChinese);
                                                var times = rtfDoc.createFont("Times New Roman");
                                                RtfParagraph par = rtfDoc.addParagraph(); ;
                                                par.DefaultCharFormat.Font = times;
                                                par.setText(p.InnerText);

                                                int start = 0;
                                                int end = 0;
                                                foreach (var r in p)
                                                {
                                                    if (r.ToString() == run)
                                                    {
                                                        string runProperties = string.Empty;
                                                        string runContext = string.Empty;
                                                        foreach (var rv in r)
                                                        {
                                                            if (rv.ToString() == run_properties)
                                                            {
                                                                foreach (var tp in rv)
                                                                {
                                                                    runProperties += tp.ToString() + '\n';
                                                                }
                                                            }
                                                            if (rv.ToString() == text)
                                                            {
                                                                runContext = rv.InnerText;
                                                                if (end != 0) start = end;
                                                                end += runContext.Length;
                                                            }
                                                        }
                                                        if (runContext.Trim() == string.Empty)
                                                            continue;

                                                        RtfCharFormat fmt = par.addCharFormat(start, end - 1);
                                                        fmt.FontSize = 18;
                                                        if (runProperties.Contains(bold)) fmt.FontStyle.addStyle(FontStyleFlag.Bold);
                                                        if (runProperties.Contains(italic)) fmt.FontStyle.addStyle(FontStyleFlag.Italic);
                                                        if (runProperties.Contains(underline)) fmt.FontStyle.addStyle(FontStyleFlag.Underline);
                                                        fmt.Font = times;

                                                        listRowData.Add(rtfDoc.render());
                                                    }
                                                }                                                
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        var temp = listRowData;
                    }
                }

                doc.Close();
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

        /// <summary>
        /// Real structure of table have 8 column and 2 row
        /// ===============================================
        /// ||  || Question Content                       ||
        /// ===============================================
        /// ||A.|| Ans 1||B.||Ans 2||C.||Ans 3||D.||Ans 4 ||
        /// ===============================================
        /// </summary>
        /// <param name="tb"></param>
        /// <returns>Check structure of table is correct</returns>
        private bool CheckTableCorrectly(Word.Table tb, QUESTION_TYPES questionType)
        {
            return tb.Columns.Count == (questionType.NumberAnswer * 2) && tb.Rows.Count == 2 && questionType.IsQuiz;
        }

        private void btnDeleteQuestion_Click(object sender, System.EventArgs e)
        {
            if (CurrentQuestionId <= 0)
            {
                MessageBox.Show(Properties.Resources.NotRowMessage, Properties.Resources.WarningDialog);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show(Properties.Resources.YesNoMessage,
                Properties.Resources.WarningDialog, MessageBoxButtons.YesNo))
            {
                _QuestionService.Delete(CurrentQuestionId);
                _QuestionService.Save();
                MessageBox.Show(Properties.Resources.MessageDeleteSuccess, Properties.Resources.Success);
                btnGetData_Click(sender, e);
            }
        }

        private void btnAddNewQuestion_Click(object sender, System.EventArgs e)
        {
            FrmEditQuestion frm = new FrmEditQuestion(CurrentQuestionTypeId, CurrentTopicId, CurrentStaffId);
            frm.ShowDialog();
            frm.Dispose();

            QUESTION_TYPES questionType = _QuestionTypeService.GetById(CurrentQuestionTypeId);
        }

        private void cbQuestionType_SelectedValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cbQuestionType.SelectedValue != null)
                {
                    txtQuestionTypeDescrition.Text = _QuestionTypeService
                       .GetById(int.Parse(cbQuestionType.SelectedValue.ToString()))
                       .Description;
                }
            }
            catch { }
            EnableDataButton(!string.IsNullOrEmpty(cbTopic.Text) && !string.IsNullOrEmpty(cbQuestionType.Text));
        }

        private void cbTopic_SelectedValueChanged(object sender, System.EventArgs e)
        {
            EnableDataButton(!string.IsNullOrEmpty(cbTopic.Text) && !string.IsNullOrEmpty(cbQuestionType.Text));
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            CurrentQuestionId = listQuestion[++CurrentQuestionIndex].QuestionID;
            InitControl(CurrentQuestionId);
            CheckEnableButton();
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            CurrentQuestionId = listQuestion[--CurrentQuestionIndex].QuestionID;
            InitControl(CurrentQuestionId);
            CheckEnableButton();
        }

        private void CheckEnableButton()
        {
            btnBack.Enabled = !(CurrentQuestionIndex == 0);
            btnNext.Enabled = !(CurrentQuestionIndex == listQuestion.Count - 1);
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            
            if (DialogResult.Yes == MessageBox.Show(Properties.Resources.YesNoMessage,
                Properties.Resources.WarningDialog, MessageBoxButtons.YesNo))
            {
                _QuestionService.Delete(CurrentQuestionId);
                _QuestionService.Save();
                MessageBox.Show(Properties.Resources.MessageDeleteSuccess, Properties.Resources.Success);
            }
        }
    }
}