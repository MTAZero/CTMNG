using EXON.Common;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace EXON.Main.Helper
{
    public class EditorHelper
    {
        private static string GetStringByIsQuiz(IsQuizEnum status)
        {
            switch (status)
            {
                case IsQuizEnum.Quiz: return Properties.Resources.Quiz;
                case IsQuizEnum.Essay: return Properties.Resources.Essay;
            }
            return Properties.Resources.Quiz;
        }

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
        public static string ConvertOpenXMLToRFT(string xml)
        {
            string path = Path.Combine(System.Windows.Forms.Application.StartupPath, "sample.doc");
            string path1 = Path.Combine(System.Windows.Forms.Application.StartupPath, "sample1.rtf");

            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = false;

            Documents documents = app.Documents;
            Document doc = documents.Add(path);

            doc.Range().InsertXML(xml);
            doc.SaveAs(path1, WdSaveFormat.wdFormatRTF);

            doc.Close();
            app.Quit();

            RichTextBox rtb = new RichTextBox();
            rtb.LoadFile(path1);

            File.Delete(path1);
            return rtb.Rtf;
        }
    }
}