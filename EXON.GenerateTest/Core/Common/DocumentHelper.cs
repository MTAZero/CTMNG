using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Common
{
    public class DocumentHelper
    {
        public static string ConvertRTFtoText(string rtf)
        {
            try
            {
                RichTextBox rtb = new RichTextBox();
                rtb.Rtf = rtf;

                return rtb.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ConvertTexttoRTF(string text)
        {
            try
            {
                RichTextBox rtb = new RichTextBox();
                rtb.Text = text;

                return rtb.Rtf;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}