using MetroFramework.Forms;

namespace EXON.TakeExam
{
    public partial class frmTakeExam : MetroForm
    {
        public frmTakeExam()
        {
            InitializeComponent();
        }

        private void btnDangKiThi_Click(object sender, System.EventArgs e)
        {
            EXON.Register.frmRegister temp = new Register.frmRegister();
            temp.ShowDialog();
        }

        private void btnToChucThi_Click(object sender, System.EventArgs e)
        {
            EXONSYSTEM.Layout.frmConfigApplication temp = new EXONSYSTEM.Layout.frmConfigApplication();
            temp.ShowDialog();
        }
    }
}