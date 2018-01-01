using EXON.Common;
using EXON.Data.Services;
using EXON.GenerateTest.Core.Common;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucDisplayQuestion : UserControl
    {
        private QuestionService _QuestionService = new QuestionService();
        private QuestionTypeService _QuestionTypeService = new QuestionTypeService();
        private SubQuestionService _SubQuestionService = new SubQuestionService();
        private AnswerService _AnswerService = new AnswerService();
        private TopicService _TopicService = new TopicService();
        private StaffService _StaffService = new StaffService();

        public ucDisplayQuestion(int questionID, ref int index)
        {
            this.Dock = DockStyle.Top;

            InitializeComponent();
            InitializeControl(questionID,ref index);
            InitializeDetail(questionID);
        }

        private void InitializeDetail(int questionID)
        {
            QUESTION currentQuestion = _QuestionService.GetById(questionID);
            if (currentQuestion != null)
            {
                lbTopic.Text = string.Format("Chủ Đề: {0}", _TopicService
                    .GetById(currentQuestion.TopicID)
                    .TopicName);
                lbType.Text = string.Format("Thể Loại: {0}", _QuestionTypeService
                    .GetById(currentQuestion.QuestionTypeID)
                    .QuestionTypeName);
                lbLevel.Text = string.Format("Độ Khó: {0}", currentQuestion.Level);
                lbCreatedDate.Text = string.Format("Ngày Tạo: {0}",
                    DateTimeHelpers
                    .ConvertUnixToDateTime(currentQuestion.CreatedDate)
                    .ToShortDateString());
                lbCreatedBy.Text = string.Format("Người Tạo: {0}", _StaffService
                    .GetById(currentQuestion.CreatedStaffID)
                    .FullName);
                lbAcceptedBy.Text = string.Format("Người Phê Duyệt: {0}", _StaffService
                    .GetById(currentQuestion.AcceptedStaffID.Value)
                    .FullName);
            }

        }

        private void InitializeControl(int questionID,ref int index)
        {
            //pcMain.Controls.Clear();
            QUESTION currentQuestion = _QuestionService.GetById(questionID);

            if (currentQuestion != null)
            {
                QUESTION_TYPES questionType = _QuestionTypeService.GetById(currentQuestion.QuestionTypeID);
                List<SUBQUESTION> subQuestion = _SubQuestionService.GetAll(currentQuestion.QuestionID).ToList();

                int Index = questionType.NumberSubQuestion - 1;

                for (int i = questionType.NumberSubQuestion; i > 0; i--)
                {
                    CustomeGroup grb = new CustomeGroup();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Name = "SubQuestion" + i;
                    grb.Padding = new Padding(10, 5, 10, 5);
                    grb.Text = "Câu hỏi " + (index + Index--);
                    grb.ForeColor = Color.Green;

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
                        pnl.BackColor = Color.White;
                        pnl.Dock = DockStyle.Top;
                        pnl.Size = new Size(0, 30);
                        pnl.Padding = new Padding(5, 5, 0, 5);

                        Label lbl = new Label();
                        lbl.Visible = false;
                        lbl.Name = "lblQ" + i + "Ans" + j + "ID";
                        pnl.Controls.Add(lbl);

                        CustomeRichTextbox rtb = new CustomeRichTextbox();
                        rtb.ReadOnly = true;
                        rtb.SelectionFont = new System.Drawing.Font(Properties.Resources.Font, 9,
                            System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                        CustomeRichTextbox rtb = new CustomeRichTextbox();
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
                    CustomeGroup grb = new CustomeGroup();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Padding = new Padding(10, 5, 10, 5);
                    grb.Text = "Đoạn văn";

                    CustomeRichTextbox rtb = new CustomeRichTextbox();
                    rtb.ReadOnly = true;
                    rtb.SelectionFont = new Font(Properties.Resources.Font, 11);
                    rtb.Dock = DockStyle.Bottom;
                    rtb.Name = "rtbParagraph";
                    rtb.MinimumSize = new Size(0, 78);
                    rtb.ScrollToCaret();
                    rtb.Rtf = currentQuestion.QuestionContent;
                    grb.Controls.Add(rtb);

                    pcMain.Controls.Add(grb);
                }
                index += questionType.NumberSubQuestion;
            }           
            UpdateSizeControl();
        }

        private void UpdateSizeControl()
        {
            int totalHeight = 0;
            int step = 25;
            foreach (Control c in pcMain.Controls)
            {
                if (c.GetType() == typeof(CustomeGroup))
                {
                    totalHeight += c.PreferredSize.Height + step;
                    step -= 2;
                }
            }
            this.Height = pcMain.Controls.Count > 3 ? totalHeight : totalHeight + 50;
            this.PerformLayout();
        }
        public void Accepted(bool b)
        {
            pictureBox1.Visible = b;
        }
    }
}