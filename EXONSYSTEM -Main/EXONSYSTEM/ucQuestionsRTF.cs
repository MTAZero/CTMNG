using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EXONSYSTEM.Common;
using MetroFramework.Controls;
using DAO.DataProvider;

using System.Diagnostics;
using BUS;

namespace EXONSYSTEM
{
    public partial class ucQuestionsRTF : MetroUserControl
    {
        public Control mbtnControl { get; set; }
        public Questions q;
        private AnswersheetDetail AD;
        public ucQuestionsRTF()
        {
            InitializeComponent();
            this.UseCustomBackColor = true;
            this.BackColor = Constant.COLOR_WHITE;
            mpnAnswers.BackColor = Constant.COLOR_WHITE;
            pnTitleOfQuestion.BackColor = Constant.COLOR_WHITE;

        }

        //private void HandleRichTextBoxStyle(RichTextBox rtb)
        //{
        //    rtb.BackColor = this.BackColor;
        //    rtb.BorderStyle = BorderStyle.None;
        //    rtb.ReadOnly = true;
        //    rtb.Cursor = Cursors.Arrow;
        //    rtb.WordWrap = true;
        //    rtb.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.RichTexBox_ContentResized);
        //}
        //private void RichTexBox_ContentResized(object sender, ContentsResizedEventArgs e)
        //{
        //    RichTextBox rch = sender as RichTextBox;
        //    rch.ClientSize = new Size(e.NewRectangle.Width, e.NewRectangle.Height);
        //}
        private void RichTexBox_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;

            switch (rtb.Name)
            {
                case "rtbAnswerA":
                    mrbAnswerA.PerformClick();
                    break;
                case "rtbAnswerB":
                    mrbAnswerB.PerformClick();
                    break;
                case "rtbAnswerC":
                    mrbAnswerC.PerformClick();
                    break;
                case "rtbAnswerD":
                    mrbAnswerD.PerformClick();
                    break;
            }
        }
        private void ucQuestionsRTF_Load(object sender, EventArgs e)
        {
            pnTitleOfQuestion.Location = new Point(10, 10);
            pnTitleOfQuestion.Width = this.Width - 20;

            lbNumber.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Underline | FontStyle.Bold);
            lbNumber.Text = string.Format(Properties.Resources.MSG_GUI_0020, q.NO);
            lbNumber.Location = new Point(0, 0);
            lbNumber.Width = 80;

            Controllers.Instance.HandleRichTextBoxStyle(rtbTitleOfQuestion);
            rtbTitleOfQuestion.Location = new Point(lbNumber.Width, 0);
            rtbTitleOfQuestion.Width = pnTitleOfQuestion.Width - lbNumber.Width;
           
            mpnAnswers.Width = pnTitleOfQuestion.Width;
            int locationLeftRadio = lbNumber.Right / 2;

            mrbAnswerA.Location = new Point(locationLeftRadio, 0);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerA, Properties.Resources.MSG_GUI_0022);
            Controllers.Instance.HandleRichTextBoxStyle(rtbAnswerA);
            rtbAnswerA.Location = new Point(mrbAnswerA.Right + 10, 3);
            rtbAnswerA.Width = mpnAnswers.Width;
            rtbAnswerA.SelectionFont = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);

            mrbAnswerB.Location = new Point(locationLeftRadio, Controllers.Instance.GetHeightBetter(rtbAnswerA.Bottom, mrbAnswerA.Bottom) + 5);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerB, Properties.Resources.MSG_GUI_0023);
            Controllers.Instance.HandleRichTextBoxStyle(rtbAnswerB);
            rtbAnswerB.Location = new Point(mrbAnswerB.Right + 10, mrbAnswerB.Top + 3);
            rtbAnswerB.Width = mpnAnswers.Width;
            rtbAnswerB.SelectionFont = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);

            mrbAnswerC.Location = new Point(locationLeftRadio, Controllers.Instance.GetHeightBetter(rtbAnswerB.Bottom, mrbAnswerB.Bottom) + 5);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerC, Properties.Resources.MSG_GUI_0024);
            Controllers.Instance.HandleRichTextBoxStyle(rtbAnswerC);
            rtbAnswerC.Location = new Point(mrbAnswerC.Right + 10, mrbAnswerC.Top + 3);
            rtbAnswerC.Width = mpnAnswers.Width;
            rtbAnswerC.SelectionFont = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);

            mrbAnswerD.Location = new Point(locationLeftRadio, Controllers.Instance.GetHeightBetter(rtbAnswerC.Bottom, mrbAnswerC.Bottom) + 5);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerD, Properties.Resources.MSG_GUI_0025);
            Controllers.Instance.HandleRichTextBoxStyle(rtbAnswerD);
            rtbAnswerD.Location = new Point(mrbAnswerD.Right + 10, mrbAnswerD.Top + 3);
            rtbAnswerD.Width = mpnAnswers.Width;
            rtbAnswerD.SelectionFont = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);

            Binding dbTitleOfQuestion = new Binding("Rtf", q, "TitleOfQuestion");
            rtbTitleOfQuestion.DataBindings.Add(dbTitleOfQuestion);
            Binding dbAnswerA = new Binding("Rtf", q.ListAnswer[0], "AnswerContent");
            rtbAnswerA.DataBindings.Add(dbAnswerA);
            Binding dbAnswerB = new Binding("Rtf", q.ListAnswer[1], "AnswerContent");
            rtbAnswerB.DataBindings.Add(dbAnswerB);
            Binding dbAnswerC = new Binding("Rtf", q.ListAnswer[2], "AnswerContent");
            rtbAnswerC.DataBindings.Add(dbAnswerC);
            Binding dbAnswerD = new Binding("Rtf", q.ListAnswer[3], "AnswerContent");
            rtbAnswerD.DataBindings.Add(dbAnswerD);

            pnTitleOfQuestion.Height = Controllers.Instance.GetHeightBetter(lbNumber.Height, rtbTitleOfQuestion.Height);

            mpnAnswers.Location = new Point(10, pnTitleOfQuestion.Bottom);
            mpnAnswers.Height = Controllers.Instance.GetHeightBetter(rtbAnswerD.Bottom, mrbAnswerD.Bottom);
            this.Height = mpnAnswers.Bottom + 10;
        
        }
        private void mrbAnswer_CheckedChanged(object sender, EventArgs e)
        {
            ErrorController rEC = new ErrorController();
            RadioButton mrb = sender as RadioButton;
            switch (mrb.Name)
            {
                case "mrbAnswerA":
                    AD.ChoosenAnswer = q.ListAnswer[0].AnswerID;
                    StyleLabel(mrbAnswerA);
                    mbtnControl.Text = string.Format(Properties.Resources.MSG_GUI_0021, q.NO, Properties.Resources.MSG_GUI_0022);
                    break;
                case "mrbAnswerB":
                    AD.ChoosenAnswer = q.ListAnswer[1].AnswerID;
                    StyleLabel(mrbAnswerB);
                    mbtnControl.Text = string.Format(Properties.Resources.MSG_GUI_0021, q.NO, Properties.Resources.MSG_GUI_0023);
                    break;
                case "mrbAnswerC":
                    AD.ChoosenAnswer = q.ListAnswer[2].AnswerID;
                    StyleLabel(mrbAnswerC);
                    mbtnControl.Text = string.Format(Properties.Resources.MSG_GUI_0021, q.NO, Properties.Resources.MSG_GUI_0024);
                    break;
                case "mrbAnswerD":
                    AD.ChoosenAnswer = q.ListAnswer[3].AnswerID;
                    StyleLabel(mrbAnswerD);
                    mbtnControl.Text = string.Format(Properties.Resources.MSG_GUI_0021, q.NO, Properties.Resources.MSG_GUI_0025);
                    break;
            }
            AD.LastTime = Controllers.Instance.ConvertDateTimeToUnix(DAO.DAO.ConvertDateTime.GetDateTimeServer());
            AnswersheetDetailBUS.Instance.PushAnswerSheetDetail(AD, out rEC);
            if (rEC.ErrorCode == Constant.STATUS_OK)
            {
                mbtnControl.BackColor = Constant.BACKCOLOR_BUTTON_QUESTION;
                mbtnControl.ForeColor = Constant.FORCECOLOR_BUTTON_QUESTION;
                mbtnControl.Update();
                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "USER_SELECT_ANSWER", mbtnControl.Text);
            }
            else
            {
                Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), DTO.MainForm);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
            }
        }
        private void StyleLabel(RadioButton mrb)
        {
            if (mrb.Checked)
            {
                mrb.ForeColor = Constant.COLOR_RED;
            }
            else
            {
                mrb.ForeColor = Constant.COLOR_BLACK;
            }
        }
        public void HandleQuestion(Questions qs, int AnswerSheetID)
        {
            q = qs;
            AD = new AnswersheetDetail();
            AD.SubQuestionID = q.SubQuestionID;
            AD.AnswerSheetID = AnswerSheetID;
        }
        public void HandleClickRadioAnswer()
        {
            switch (this.q.AnswerChecked)
            {
                //ANS_CHECKED_A
                case 2001:
                    mrbAnswerA.PerformClick();
                    break;
                //ANS_CHECKED_B
                case 2002:
                    mrbAnswerB.PerformClick();
                    break;
                //ANS_CHECKED_C
                case 2003:
                    mrbAnswerC.PerformClick();
                    break;
                //ANS_CHECKED_D
                case 2004:
                    mrbAnswerD.PerformClick();
                    break;
            }
        }
    }
}
