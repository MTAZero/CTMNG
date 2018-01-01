using EXON.Main.Core;
using System;
using System.Windows.Forms;

namespace EXON.Main.Module
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
    }

    public class BaseModule : BaseControl
    {
        protected string partName = string.Empty;
        internal FrmMain OwnerForm { get { return this.FindForm() as FrmMain; } }

        public BaseModule()
        {
        }

        internal virtual void ShowModule(bool firstShow)
        {
            FrmMain owner = OwnerForm;
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