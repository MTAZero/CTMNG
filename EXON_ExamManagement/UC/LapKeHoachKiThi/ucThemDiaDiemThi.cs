using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON_ExamManagement.UC.UI;

namespace EXON_ExamManagement.UC.LapKeHoachKiThi
{
    public partial class ucThemDiaDiemThi : UserControl
    {
        private List<UserControl> listUc = new List<UserControl>();
        public ucThemDiaDiemThi()
        {
            InitializeComponent();
            panelStatus.Controls.Clear();

            panelStatus.Controls.Clear();
            listUc = ucLapKeHoachThiHelper.getListUserControl(4);
            panelStatus.Controls.AddRange(listUc.ToArray());
        }

        private void ucThemDiaDiemThi_Load(object sender, EventArgs e)
        {
        }
    }
}
