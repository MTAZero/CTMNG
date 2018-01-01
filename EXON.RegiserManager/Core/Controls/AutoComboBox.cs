using System.Windows.Forms;

namespace EXON.RegisterManager.Core.Controls
{
    public partial class AutoComboBox : ComboBox
    {
        public AutoComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.CacheText, true);

            this.AutoCompleteMode = AutoCompleteMode.Append;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}