using EXON.Data.Services;
using EXON.GenerateTest.Core.Common;
using EXON.GenerateTest.Core.Controls;
using EXON.GenerateTest.Core.Tags;
using EXON.GenerateTest.Settings;
using EXON.Model.Models;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GenerateTest
{
    public partial class frmMain : MetroForm
    {
        #region Service

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

        private int CurrentSubjectID;
        private ModulesNavigator modulesNavigator;

        public frmMain(int ConstestID, int type)
        {
            InitializeComponent();
            InitializeService();
            InitializeButton(ConstestID);
            InitializeRibbonPage();
            InitializeTabPage(type);
            RibbonButtonsInitialize();
            LoadSettings();
            StaticResource.ContestID = ConstestID;
            BaseControl.CurrentStaffId = 6;
        }

        private void LoadSettings()
        {
            XMLSettings.ReadSettings();
            upNumberOfTest.TextBoxText = XMLSettings.NumberOfOriginalTest.ToString();
            cbAutoNumberOfTest.Checked = XMLSettings.AutoNumberOfTest;
            cbOriginalTestNotSame.Checked = XMLSettings.GenerateTestNotSame;
        }

        private void InitializeRibbonPage()
        {
            ribbonTab1.Tag = Properties.Resources.StructureTestName;
            ribbonTab2.Tag = Properties.Resources.CreateOriginalTest;
            ribbonTab3.Tag = Properties.Resources.CreateTest;
        }

        private void InitializeService()
        {
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

        private void InitializeButton(int currentContestID)
        {
            List<SCHEDULE> listSchedule = _ScheduleService.GetAllByContest(currentContestID).ToList();
            List<SUBJECT> listSubject = _SubjectService.GetAll().ToList();
            var listShiftJoin = (from sc in listSchedule
                                 from sb in listSubject
                                 where sb.SubjectID == sc.SubjectID
                                 select new
                                 {
                                     SubjectName = sb.SubjectName + " (" + sc.TimeOfTest / 60 + "p)",
                                     SubjectCode = sb.SubjectCode,
                                     SubjectID = sc.SubjectID,
                                     ScheduleID = sc.ScheduleID,
                                     //NumContestant = GetNumContestant(sc.SubjectID, currentContestID)
                                 }).Distinct().ToList();

            foreach (var s in listShiftJoin)
            {
                CustomeButton button = new CustomeButton
                {
                    Name = s.SubjectID.ToString(),
                    Text = s.SubjectName/* + "(" + s.NumContestant.ToString() + ")"*/
                };
                button.Click += button_Click;
                pnButton.Controls.Add(button);
            }
        }

        private void InitializeTabPage(int type)
        {
            modulesNavigator = new ModulesNavigator(pnMain, Ribbon);
            if (type == 0)
            {
                mtcMain.TabPages.Remove(mtpTest);
                mtcMain.SelectedTab = mtpStructure;
            }
            else
            {
                mtcMain.SelectedTab = mtpTest;
                mtcMain.TabPages.Remove(mtpStructure);
                mtcMain.TabPages.Remove(mtpOriginalTest);
            }

            mtpStructure.Tag = new MetroTabPageGroupTagObject(Properties.Resources.StructureTestName, typeof(ucCreateStructure));
            mtpTest.Tag = new MetroTabPageGroupTagObject(Properties.Resources.CreateTest, typeof(ucCreateTest));
            mtpOriginalTest.Tag = new MetroTabPageGroupTagObject(Properties.Resources.CreateOriginalTest, typeof(ucCreateOriginalTest));
        }

        private void button_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnButton.Controls)
            {
                if (c.GetType() == typeof(CustomeButton))
                {
                    c.BackColor = System.Drawing.Color.Transparent;
                    c.ForeColor = System.Drawing.Color.Black;
                }
            }
            (sender as Button).BackColor = System.Drawing.Color.DarkOrange;
            (sender as Button).ForeColor = System.Drawing.Color.White;

            try
            {
                CurrentSubjectID = int.Parse((sender as Button).Name);
            }
            catch
            {
                CurrentSubjectID = -1;
            }
            StaticResource.SubjectID = CurrentSubjectID;
            modulesNavigator.CurrentModule.Refresh();
            SettingsRefresh();
        }

        private void SettingsRefresh()
        {
            if (XMLSettings.AutoNumberOfTest && modulesNavigator.CurrentModule.GetType()==typeof(ucCreateOriginalTest))
                upNumberOfTest.TextBoxText = (modulesNavigator.CurrentModule as ucCreateOriginalTest).AutoNumOfTest.ToString();
        }

        private int GetNumContestant(int subjectID, int currentContestID)
        {
            int ScheduleID = _ScheduleService.GetByContestAndSubject(currentContestID, subjectID).ScheduleID;
            return _ContestantShiftService.GetAllBySchedule(ScheduleID).Count();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Log.Instance.WriteLog(LogType.INFO, "Loading form main");
            this.WindowState = FormWindowState.Maximized;
            XMLSettings.ReadSettings();

            if (pnButton.Controls.Count > 0)
            {
                pnButton.Controls[0].BackColor = System.Drawing.Color.DarkOrange;
                pnButton.Controls[0].ForeColor = System.Drawing.Color.White;
                StaticResource.SubjectID = int.Parse((pnButton.Controls[0] as Button).Name);
            }
            modulesNavigator.ChangeSelectedItem(mtcMain.SelectedTab as MetroTabPage, null);
        }

        private void RibbonButtonsInitialize()
        {
            InitBarButtonItem(rbiCreateTest, TagResource.CreateTest, Properties.Resources.CreateTest);

            InitBarButtonItem(rbiCreateStruct, TagResource.CreateStruct, Properties.Resources.StructureTestName);
            InitBarButtonItem(rbiUpdateStruct, TagResource.UpdateStruct, Properties.Resources.UpdateStruct);
            InitBarButtonItem(rbiExportStructToDoc, TagResource.ExportStructToDoc, Properties.Resources.ExportToDOC);

            InitBarButtonItem(rbiCreateOriginalTest, TagResource.CreateOriginalTest, Properties.Resources.CreateOriginalTest);
            InitBarButtonItem(rbiDeleteOriginalTest, TagResource.DeleteOriginalTest, Properties.Resources.CreateOriginalTest);
            InitBarButtonItem(rbiAccepted, TagResource.AcceptTest, Properties.Resources.Accepted);
        }

        private void InitBarButtonItem(RibbonButton buttonItem, object tag, string description)
        {
            buttonItem.Click += new EventHandler(bbi_ItemClick);
            buttonItem.ToolTip = description;
            buttonItem.Tag = tag;
        }

        private void bbi_ItemClick(object sender, EventArgs e)
        {
            try
            {
                Log.Instance.WriteLog(LogType.INFO, (sender as RibbonButton).Text + " click!");
                modulesNavigator.CurrentModule.ButtonClick(string.Format("{0}", ((RibbonButton)sender).Tag));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.WarningDialog);
            }
        }

        private void mtcMain_Selected(object sender, TabControlEventArgs e)
        {
            MetroTabControl owne = sender as MetroTabControl;
            if (owne == null)
                return;
            modulesNavigator.ChangeSelectedItem(owne.SelectedTab as MetroTabPage, null);
        }

        private void cbAutoNumberOfTest_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            upNumberOfTest.Enabled = !cbAutoNumberOfTest.Checked;
            XMLSettings.WriteValue("AutoNumberOfTest", cbAutoNumberOfTest.Checked.ToString());
            XMLSettings.ReadSettings();

            if (XMLSettings.AutoNumberOfTest)
                upNumberOfTest.TextBoxText = (modulesNavigator.CurrentModule as ucCreateOriginalTest).AutoNumOfTest.ToString();
        }

        private void cbOriginalTestNotSame_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            XMLSettings.WriteValue("GenerateTestNotSame", cbOriginalTestNotSame.Checked.ToString());
            XMLSettings.ReadSettings();
        }

        private void upNumberOfTest_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(upNumberOfTest.TextBoxText))
                return;
            try
            {
                int.Parse(upNumberOfTest.TextBoxText);
            }
            catch
            {
                upNumberOfTest.TextBoxTextChanged -= upNumberOfTest_TextBoxTextChanged;
                MetroMessageBox.Show(this, "Vui lòng nhập số", Properties.Resources.WarningDialog);               
                upNumberOfTest.TextBoxText = "1";

                upNumberOfTest.TextBoxTextChanged += upNumberOfTest_TextBoxTextChanged;
                return;
            }

            XMLSettings.WriteValue("NumberOfOriginalTest", upNumberOfTest.TextBoxText);
            XMLSettings.ReadSettings();
        }
    }
}