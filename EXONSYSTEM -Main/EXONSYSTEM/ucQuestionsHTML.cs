using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Drawing.Html;
using System.Threading;
using DAO.DataProvider;
using System.Diagnostics;
using EXONSYSTEM.Common;
using BUS;

namespace EXONSYSTEM
{
    public partial class ucQuestionsHTML : MetroUserControl
    {
        public Control mbtnControl { get; set; }
        public Questions q;
        private AnswersheetDetail AD;
        public ucQuestionsHTML()
        {
            InitializeComponent();
            this.UseCustomBackColor = true;
            this.BackColor = Constant.COLOR_WHITE;
            pnAnswer.BackColor = Constant.COLOR_WHITE;
        }

        private void htmlLabel_Click(object sender, EventArgs e)
        {
            HtmlLabel lb = sender as HtmlLabel;

            switch (lb.Name)
            {
                case "hlbAnswerA": mrbAnswerA.PerformClick(); break;
                case "hlbAnswerB": mrbAnswerB.PerformClick(); break;
                case "hlbAnswerC": mrbAnswerC.PerformClick(); break;
                case "hlbAnswerD": mrbAnswerD.PerformClick(); break;
            }
        }

        private void ucQuestions_Load(object sender, EventArgs e)
        {
            hlbTitleOfQuestion.Text = string.Format(Properties.Resources.MSG_GUI_0026, q.QuestionID, q.TitleOfQuestion);
            Binding dbAnswerA = new Binding("Text", q.ListAnswer[0], "AnswerContent");
            hlbAnswerA.DataBindings.Add(dbAnswerA);
            Binding dbAnswerB = new Binding("Text", q.ListAnswer[1], "AnswerContent");
            hlbAnswerB.DataBindings.Add(dbAnswerB);
            Binding dbAnswerC = new Binding("Text", q.ListAnswer[2], "AnswerContent");
            hlbAnswerC.DataBindings.Add(dbAnswerC);
            Binding dbAnswerD = new Binding("Text", q.ListAnswer[3], "AnswerContent");
            hlbAnswerD.DataBindings.Add(dbAnswerD);

            Controllers.Instance.SetStyleHtmlLabel(hlbTitleOfQuestion);
            hlbTitleOfQuestion.Width = this.Width - 30;
            hlbTitleOfQuestion.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);
            hlbTitleOfQuestion.Location = new Point(20, 10);
            hlbTitleOfQuestion.Height = Convert.ToInt32(hlbTitleOfQuestion.HtmlContainer.Bounds.Height) + 20;
            pnAnswer.Width = hlbTitleOfQuestion.Width;

            mrbAnswerA.Location = new Point(0, 0);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerA, Properties.Resources.MSG_GUI_0022);
            Controllers.Instance.SetStyleHtmlLabel(hlbAnswerA);
            hlbAnswerA.Location = new Point(mrbAnswerA.Width + 10, 0);
            hlbAnswerA.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);
            hlbAnswerA.Width = pnAnswer.Width - hlbAnswerA.Left;
            hlbAnswerA.Height = Convert.ToInt32(hlbAnswerA.HtmlContainer.Bounds.Height) + 20;

            mrbAnswerB.Location = new Point(0, Controllers.Instance.GetHeightBetter(hlbAnswerA.Bottom, mrbAnswerA.Bottom) + 5);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerB, Properties.Resources.MSG_GUI_0023);
            Controllers.Instance.SetStyleHtmlLabel(hlbAnswerB);
            hlbAnswerB.Location = new Point(mrbAnswerB.Width + 10, hlbAnswerA.Bottom);
            hlbAnswerB.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);
            hlbAnswerB.Width = pnAnswer.Width - hlbAnswerB.Left;
            hlbAnswerB.Height = Convert.ToInt32(hlbAnswerB.HtmlContainer.Bounds.Height) + 20;

            mrbAnswerC.Location = new Point(0, Controllers.Instance.GetHeightBetter(hlbAnswerB.Bottom, mrbAnswerB.Bottom) + 5);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerC, Properties.Resources.MSG_GUI_0024);
            Controllers.Instance.SetStyleHtmlLabel(hlbAnswerC);
            hlbAnswerC.Location = new Point(mrbAnswerC.Width + 10, hlbAnswerB.Bottom);
            hlbAnswerC.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);
            hlbAnswerC.Width = pnAnswer.Width - hlbAnswerC.Left;
            hlbAnswerC.Height = Convert.ToInt32(hlbAnswerC.HtmlContainer.Bounds.Height) + 20;

            mrbAnswerD.Location = new Point(0, Controllers.Instance.GetHeightBetter(hlbAnswerC.Bottom, mrbAnswerC.Bottom) + 5);
            Controllers.Instance.SetStyleRadioButton(mrbAnswerD, Properties.Resources.MSG_GUI_0025);
            Controllers.Instance.SetStyleHtmlLabel(hlbAnswerD);
            hlbAnswerD.Location = new Point(mrbAnswerD.Width + 10, hlbAnswerC.Bottom);
            hlbAnswerD.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);
            hlbAnswerD.Width = pnAnswer.Width - hlbAnswerD.Left;
            hlbAnswerD.Height = Convert.ToInt32(hlbAnswerD.HtmlContainer.Bounds.Height) + 20;

            pnAnswer.Location = new Point(hlbTitleOfQuestion.Left, hlbTitleOfQuestion.Bottom);
            pnAnswer.Height = Controllers.Instance.GetHeightBetter(hlbAnswerD.Bottom, mrbAnswerD.Bottom);
            this.Height = pnAnswer.Bottom + 10;
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
            AD.LastTime = Controllers.Instance.ConvertDateTimeToUnix(DateTime.Now);
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
        public void HandleClickMrbtnAnswer()
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
