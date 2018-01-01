using EXON.Common;
using EXON.Data.Services;
using EXON.Main.Core.Controls;
using EXON.Main.Module.Controls;
using EXON.Main.Module.Forms;
using EXON.Model.Models;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module
{
    public partial class FrmMain : MetroForm
    {
        private ModulesNavigator modulesNavigator;
        private string[] positions;
        private StaffPositionService _StaffPositionService;
        private StaffService _StaffService;
        private PositionService _PositionService;

        private FrmLogin login;

        public FrmMain()
        {
            InitializeComponent();
            RibbonButtonsInitialize();
            InitializeLogin();
        }

        private void InitializePerminsion()
        {
            _StaffPositionService = new StaffPositionService();
            _StaffService = new StaffService();
            _PositionService = new PositionService();

            positions = (from sp in _StaffPositionService.GetAll(BaseControl.CurrentStaffId)
                         from p in _PositionService.GetAll()
                         where sp.PositionID == p.PositionID
                         select p.PositionCode.ToUpper()).ToArray();

            foreach (ToolStripMenuItem t in mMain.Items)
            {
                t.Available = true;
                foreach (ToolStripItem ts in t.DropDownItems)
                {
                    ts.Available = true;
                }
            }

            if (!positions.Contains(PositionEnum.GV.ToString()) && !positions.Contains(PositionEnum.CNBM.ToString()))
            {
                bbiCauHoi.Available = false;
                bbiCongViec.Available = false;
            }
            if (!positions.Contains(PositionEnum.CNBM.ToString()) && !positions.Contains(PositionEnum.TK.ToString()))
            {
                bbiLoaiCauHoi.Available = false;
                bbiCauTrucDe.Available = false;
                bbiChuDeMonHoc.Available = false;
                bbiPheDuyet.Available = false;
                bbiPhanCong.Available = false;
            }

            if (!positions.Contains(PositionEnum.TLKT.ToString()) && !positions.Contains(PositionEnum.TPKT.ToString()))
            {
                bbiDeThiGoc.Available = false;
                bbiSinhDeThi.Available = false;
            }
            foreach (ToolStripMenuItem t in mMain.Items)
            {
                bool isAvailable = false;
                foreach (ToolStripItem ts in t.DropDownItems)
                {
                    if (ts.GetType() == typeof(ToolStripSeparator)) continue;
                    if (ts.Available)
                    {
                        isAvailable = true;
                        break;
                    }
                }
                t.Available = isAvailable;
            }

            STAFF currentStaff = _StaffService.GetById(BaseControl.CurrentStaffId);
        }

        private void InitializeLogin()
        {
            //this.Hide();
            //if (login == null) login = new FrmLogin();
            //login.ShowDialog();

            if (modulesNavigator == null) modulesNavigator = new ModulesNavigator(pcMain);
            //if (login.LoginStatus == Common.LoginStatus.Login)
            //{
            //    BaseControl.CurrentStaffId = login.CurrentStaffId;
            //    pcMain.Controls.Clear();
            //    pcMain.Controls.Add(new ucBackgroundMain());
            //    modulesNavigator.ChangeGroup(new ucQuestion());
            //    this.Show();

            //    //InitializePerminsion();
            //}
            //else if (login.LoginStatus == LoginStatus.Close) modulesNavigator = null;

            BaseControl.CurrentStaffId = 6;
            pcMain.Controls.Clear();
            modulesNavigator.ChangeGroup(new ucQuestion());
        }

        private void RibbonButtonsInitialize()
        {
            InitBarButtonItem(bbiCauHoi, TagResources.Question, Properties.Resources.bbiQuestionDescription);
            InitBarButtonItem(bbiLoaiCauHoi, TagResources.QuestionType, Properties.Resources.bbiQuestionTypeDescription);
            InitBarButtonItem(bbiCauTrucDe, TagResources.StructureTest, Properties.Resources.bbiStructureTestDescription);
            InitBarButtonItem(bbiPheDuyet, TagResources.Accepted, Properties.Resources.bbiAcceptedDescription);
            InitBarButtonItem(bbiDeThiGoc, TagResources.OriginalTest, Properties.Resources.bbiOriginalTestDescription);
            InitBarButtonItem(bbiChuDeMonHoc, TagResources.Topic, Properties.Resources.bbiTopicDescription);
            InitBarButtonItem(bbiSinhDeThi, TagResources.Test, Properties.Resources.bbiTestDescription);
            InitBarButtonItem(bbiPhanCong, TagResources.Task, Properties.Resources.bbiTaskDescription);
            InitBarButtonItem(bbiCongViec, TagResources.MyTask, Properties.Resources.bbiMyTaskDescription);
            InitBarButtonItem(bbiTaiKhoan, TagResources.Account, Properties.Resources.bbiAccount);
            InitBarButtonItem(bbiDoiMatKhau, TagResources.ChangePassword, Properties.Resources.bbiChangePassword);
        }

        private void InitBarButtonItem(ToolStripItem buttonItem, object tag, string description)
        {
            buttonItem.Click += new EventHandler(bbi_ItemClick);
            buttonItem.ToolTipText = description;
            buttonItem.Tag = tag;
        }

        private void bbi_ItemClick(object sender, EventArgs e)
        {
            try
            {
                switch (((ToolStripItem)sender).Tag.ToString())
                {
                    case TagResources.Question:
                        ucQuestion question = new ucQuestion();
                        modulesNavigator.ChangeGroup(question);
                        break;

                    case TagResources.QuestionType:
                        ucQuestionType questionType = new ucQuestionType();
                        modulesNavigator.ChangeGroup(questionType);
                        break;

                    case TagResources.StructureTest:
                        ucStructureTest structureTest = new ucStructureTest();
                        modulesNavigator.ChangeGroup(structureTest);
                        break;

                    case TagResources.Task:
                        ucTask task = new ucTask();
                        modulesNavigator.ChangeGroup(task);
                        break;

                    case TagResources.Accepted:
                        ucAcceptQuestion acceptQuestion = new ucAcceptQuestion();
                        modulesNavigator.ChangeGroup(acceptQuestion);
                        break;

                    case TagResources.OriginalTest:
                        ucOriginalTest originalTest = new ucOriginalTest();
                        modulesNavigator.ChangeGroup(originalTest);
                        break;

                    case TagResources.Topic:
                        ucTopic topic = new ucTopic();
                        modulesNavigator.ChangeGroup(topic);
                        break;

                    case TagResources.Test:
                        ucTest test = new ucTest();
                        modulesNavigator.ChangeGroup(test);
                        break;
                }
                if (modulesNavigator == null) this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.WarningDialog);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (modulesNavigator == null)
                this.Close();
        }
    }
}