using System;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class CustomeRichTextbox : RichTextBox
    {
        public CustomeRichTextbox()
        {
            this.BackColor = System.Drawing.Color.White;
            this.WordWrap = true;
            this.BorderStyle = BorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(10, 50);
            this.ContentsResized += rtb_ContentsResized;
            this.TextChanged += rtb_TextChanged;
        }

        private void rtb_TextChanged(object sender, EventArgs e)
        {
            this.SelectAll();
            this.SelectionAlignment = HorizontalAlignment.Left;
            this.DeselectAll();
        }

        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
        }
    }
}