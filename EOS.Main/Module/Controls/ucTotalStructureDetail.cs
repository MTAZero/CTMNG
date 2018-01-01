using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucTotalStructureDetail : UserControl
    {
        public ucTotalStructureDetail(int numQuestion = 0, double score = 0)
        {
            InitializeComponent();
            SetValue(numQuestion, score);
        }

        public void SetValue(int numQuestion, double score)
        {
            lbScore.Text = score.ToString("00.00");
            lbNoQ.Text = numQuestion.ToString();
        }
    }
}