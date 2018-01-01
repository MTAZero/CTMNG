using EXON.Common;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GenerateTest.Core.Controls
{
    public class ModulesNavigator
    {
        private Panel panel;
        private Ribbon ribbon;

        public ModulesNavigator(Panel panel, Ribbon ribbon)
        {
            this.panel = panel;
            this.ribbon = ribbon;
        }

        public void ChangeSelectedItem(MetroTabPage link, object moduleData)
        {
            bool allowSetVisiblePage = true;
            MetroTabPageGroupTagObject groupObject = link.Tag as MetroTabPageGroupTagObject;
            if (groupObject == null)
                return;

            List<RibbonTab> deferredPagesToShow = new List<RibbonTab>();
            foreach (RibbonTab page in ribbon.Tabs)
            {
                if (!string.IsNullOrEmpty(string.Format("{0}", page.Tag)))
                {
                    bool isPageVisible = groupObject.Name.Equals(page.Tag);
                    if (isPageVisible != page.Visible && isPageVisible)
                        deferredPagesToShow.Add(page);
                    else
                        page.Visible = isPageVisible;
                }
                if (page.Visible && allowSetVisiblePage)
                {
                    ribbon.ActiveTab = page;
                    allowSetVisiblePage = false;
                }
            }
            bool firstShow = groupObject.Module == null;
            if (firstShow)
            {
                SplashScreenManager.ShowSplashScreen();
                ConstructorInfo constructorInfoObj = groupObject.ModuleType.GetConstructor(Type.EmptyTypes);
                if (constructorInfoObj != null)
                {
                    groupObject.Module = constructorInfoObj.Invoke(null) as BaseModule;
                    groupObject.Module.InitModule();
                }
                SplashScreenManager.CloseForm();
            }
            else groupObject.Module.Refresh();

            foreach (RibbonTab page in deferredPagesToShow)
            {
                page.Visible = true;
            }
            foreach (RibbonTab page in ribbon.Tabs)
            {
                if (page.Visible)
                {
                    ribbon.ActiveTab = page;
                    break;
                }
            }

            if (groupObject.Module != null)
            {
                if (panel.Controls.Count > 0)
                {
                    BaseModule currentModule = panel.Controls[0] as BaseModule;
                    if (currentModule != null)
                        currentModule.HideModule();
                }

                panel.Controls.Clear();
                panel.Controls.Add(groupObject.Module);
                groupObject.Module.Dock = DockStyle.Fill;
                groupObject.Module.ShowModule(firstShow);
            }
        }

        public void ChangeModule(object moduleData)
        {
            bool firstShow = moduleData != null;
            if (firstShow)
            {
                try { (moduleData as BaseModule).InitModule(); }
                catch (Exception ex)
                {
                    Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
                }
            }

            (moduleData as BaseModule).ShowModule(firstShow);
            panel.Controls.Clear();
            panel.Controls.Add(moduleData as Control);
            (moduleData as UserControl).Dock = DockStyle.Fill;
        }

        public BaseModule CurrentModule
        {
            get
            {
                if (panel.Controls.Count == 0) return null;
                return panel.Controls[0] as BaseModule;
            }
        }
    }

    public class BaseControl : UserControl
    {
        public BaseControl()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void ActiveLookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            LookAndFeelStyleChanged();
        }

        protected virtual void LookAndFeelStyleChanged()
        {
        }

        public virtual string ModuleName { get { return this.GetType().Name; } }

        public static int CurrentStaffId { get; set; }
    }

    public class BaseModule : BaseControl
    {
        protected string partName = string.Empty;
        internal frmMain OwnerForm { get { return this.FindForm() as frmMain; } }
        protected Ribbon MainRibbon { get { return OwnerForm.Ribbon; } }

        public BaseModule()
        {
            if (OwnerForm == null)
                return;
        }

        internal virtual void ShowModule(bool firstShow)
        {
            frmMain owner = OwnerForm;
            if (owner == null) return;

            owner.ResetText();
            owner.Text = ModuleName;
        }

        public virtual void FocusObject(object obj)
        {
        }

        public virtual void HideModule()
        {
        }

        public virtual void InitModule()
        {
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
            Log.Instance.WriteLog(LogType.INFO, "Initialize module for " + ModuleName);
        }

        public override string ModuleName { get { return this.GetType().Name; } }
        public string PartName { get { return partName; } }

        protected internal virtual void ButtonClick(string tag)
        {
        }
    }

    public class MetroTabPageGroupTagObject
    {
        private string name;
        private Type moduleType;
        private BaseModule module;

        public MetroTabPageGroupTagObject(string name, Type moduleType)
        {
            this.name = name;
            this.moduleType = moduleType;
            module = null;
        }

        public string Name { get { return name; } }
        public Type ModuleType { get { return moduleType; } }

        public BaseModule Module
        {
            get { return module; }
            set { module = value; }
        }
    }
}