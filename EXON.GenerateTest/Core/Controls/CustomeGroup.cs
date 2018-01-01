using System;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class CustomeGroup : GroupBox
    {
        public CustomeGroup()
        {
            this.BackColor = System.Drawing.Color.Transparent;
            this.ControlAdded += control_add;
        }

        private void control_add(object sender, ControlEventArgs e)
        {
            if ((sender as CustomeGroup).Controls.Count >= 6)
            {
                (sender as CustomeGroup).MinimumSize = new System.Drawing.Size(0, 250);
            }
        }
    }
}