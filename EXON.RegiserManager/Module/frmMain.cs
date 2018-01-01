using EOS.Main.Module.Forms;
using EXON.Common;
using EXON.Data.Services;
using EXON.RegisterManager.Module.Controls;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace EXON.RegisterManager.Module
{
    public partial class frmMain : MetroForm
    {
        public ModulesNavigator modulesNavigator;
        private ContestService _ContestService;
        private StaffService _StaffService;
        //int _contestID = 0;
        private int CurrentContestID
        {
            get;set;
        }
        private FrmLogin login;

        public frmMain()
        {
            InitializeService();
            InitializeComponent();
            InitializeLogin();
            //RibbonButtonsInitialize();
            //InitializeTreeView();
            InitializeUcDangKy();

        }
        public frmMain(int contestID, int staffid)
        {
            CurrentContestID = contestID;
            BaseControl.CurrentStaffId = staffid;
            InitializeService();
            InitializeComponent();
            InitializeLogin();
            //RibbonButtonsInitialize();
            //InitializeTreeView();
            InitializeUcDangKy();
            

        }
        private void InitializeService()
        {
            _ContestService = new ContestService();
            _StaffService = new StaffService();
        }

        //private void InitializeTreeView()
        //{
        //    tvMain.Nodes.Clear();
        //    List<CONTEST> listContest;
        //    _ContestService = new ContestService();
        //    if (rbtnInRegisterTime.Checked)
        //    {
        //        listContest = _ContestService.GetInRegisterStatus().ToList();
        //    }

        //    else listContest = _ContestService.GetAllAccepted().ToList();
        //    //#else
        //    //            listContest = _ContestService.GetAllAccepted().ToList();
        //    //#endif
        //    tvMain.Nodes.Add(Properties.Resources.ListContest);
        //    foreach (CONTEST c in listContest)
        //    {
        //        TreeNode treeNode = new TreeNode()
        //        {
        //            Name = c.ContestID.ToString(),
        //            Text = c.ContestName

        //        };
        //        if (c.Status == 1) treeNode.ForeColor = Color.Green;
        //        else treeNode.ForeColor = Color.Maroon;
        //        tvMain.Nodes[0].Nodes.Add(treeNode);
        //    }
        //    tvMain.ExpandAll();
        //    ChangeBackgroundMenuStrip(2);
        //}

        private void InitializeLogin()
        {
            //this.Hide();
            //if (login == null) login = new FrmLogin();
            //login.ShowDialog();

            if (modulesNavigator == null) modulesNavigator = new ModulesNavigator(pcMain);

            //BaseControl.CurrentStaffId = 0; // login.CurrentStaffId;
            pcMain.Controls.Clear();
            modulesNavigator.ChangeGroup(new ucQuanLiDangKi());
            this.Show();

            //BaseControl.CurrentStaffId = 7;
            if (BaseControl.CurrentStaffId > 0)
            {
                STAFF currentStaff = _StaffService.GetById(BaseControl.CurrentStaffId);
                bhiStaff.Text = "Xin Chào " + currentStaff.FullName;
            }
        }
        private void InitializeUcDangKy()
        {
            try
            {
                ucQuanLiDangKi dangki = new ucQuanLiDangKi();
                modulesNavigator.ChangeGroup(dangki);
                BaseModule.CurrentContestID = CurrentContestID;
                _ContestService = new ContestService();
                CONTEST contest = new CONTEST();
                contest = _ContestService.GetById(CurrentContestID);
                BaseModule.CurrentContestStatus = contest.Status;
                stripStatusContest.Text = "Kỳ thi " + contest.ContestName;
                modulesNavigator.CurrentModule.Refresh();
            }
            catch(Exception ex)
            { }

        }
        private void RibbonButtonsInitialize()
        {
            //InitBarButtonItem(btnDangKi, TagResources.DangKi, Properties.Resources.bbiDangKi);
            //InitBarButtonItem(btnThiSinh, TagResources.ThiSinh, Properties.Resources.bbiThiSinh);
            //InitBarButtonItem(bbiLogout, TagResources.Logout, Properties.Resources.bbiLogout);
        }

        private void InitBarButtonItem(ToolStripMenuItem buttonItem, object tag, string description)
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
                    case TagResources.DangKi:
                        ucQuanLiDangKi dangki = new ucQuanLiDangKi();
                        modulesNavigator.ChangeGroup(dangki);
                        break;
                    case TagResources.ThiSinh:
                        ucQuanLiThiSinh thisinh = new ucQuanLiThiSinh();
                        modulesNavigator.ChangeGroup(thisinh);
                        break;
                    case TagResources.Logout:
                        InitializeLogin();
                        break;
                    default:
                        dangki = new ucQuanLiDangKi();
                        modulesNavigator.ChangeGroup(dangki);
                        break;
                }
                if (modulesNavigator == null) this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.WarningDialog);
            }
        }

        //private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    if (tvMain.SelectedNode.Text == tvMain.Nodes[0].Text) return;
        //    BaseModule.CurrentContestID = CurrentContestID;
        //    _ContestService = new ContestService();
        //    CONTEST contest = new CONTEST();
        //    contest = _ContestService.GetById(CurrentContestID);
        //    BaseModule.CurrentContestStatus = contest.Status;
        //    stripStatusContest.Text = "Kỳ thi " + tvMain.SelectedNode.Text;
        //    modulesNavigator.CurrentModule.Refresh();
        //}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //foreach (ToolStripMenuItem item in menuStrip1.Items)
            //    item.BackColor = Color.White;
            //if (e.ClickedItem.BackColor != Color.LightBlue)
            //    e.ClickedItem.BackColor = Color.LightBlue;
        }

        public void ChangeBackgroundMenuStrip(int State)
        {
            //switch (State)
            //{
            //    case 1:
            //        menuStrip1.Items[1].BackColor = Color.LightBlue;
            //        menuStrip1.Items[0].BackColor = Color.White;
            //        break;
            //    case 2:
            //        menuStrip1.Items[1].BackColor = Color.White;
            //        menuStrip1.Items[0].BackColor = Color.LightBlue;
            //        break;
            //}
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (modulesNavigator == null)
                this.Close();
        }
        //private void btnFilter_Click(object sender, EventArgs e)
        //{
        //    InitializeTreeView();
        //}
    }
}