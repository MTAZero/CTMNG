using EXON.RegisterManager.Core;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace EXON.RegisterManager.Module
{
    public class ModulesNavigator
    {
        private Panel panel;

        public ModulesNavigator(Panel panel)
        {
            this.panel = panel;
        }

        public void ChangeGroup(object moduleData)
        {
            bool firstShow = moduleData != null;
            if (firstShow)
            {
                
                try { (moduleData as BaseModule).InitModule(); }
                catch (Exception ex)
                {
                    string s = ex.Message;
#if DEBUG
                    MessageBox.Show(ex.Message, Properties.Resources.Error);
#endif
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

        public static int CurrentContestID { get; set; }
        public static int CurrentContestStatus { get; set; }
    }

    public class BaseModule : BaseControl
    {
        protected string partName = string.Empty;
        internal frmMain OwnerForm { get { return this.GetParentForm(this.Parent) as frmMain; } }

        private Form GetParentForm(Control parent)
        {
            if (parent == null) return null;
            if (parent is Form)
                return parent as Form;

            return parent.FindForm();
        }

        public BaseModule()
        {
        }

        internal virtual void ShowModule(bool firstShow)
        {
            frmMain owner = OwnerForm;
            if (owner == null) return;
            owner.Text = ModuleName;
        }

        internal virtual void FocusObject(object obj)
        {
        }

        internal virtual void HideModule()
        {
        }

        internal virtual void InitModule()
        {
        }

        protected internal virtual void ButtonClick(string tag)
        {
        }

        public override string ModuleName { get { return this.GetType().Name; } }
        public string PartName { get { return partName; } }
    }
}