using System.Drawing;
using System.Windows.Forms;

namespace EXON.Main.Core.Controls
{
    public partial class BufferPanel : Panel
    {
        public BufferPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.CacheText, true);

            this.AutoScroll = true;
            this.BackColor = Color.White;
            UpdateStyles();
        }
    }
}