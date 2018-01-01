using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON_ExamManagement.UC.UI
{
    public partial class ucBtnStep : UserControl
    {
        public Color color { get; set; }
        public Color BGColor { get; set; }
        public int STT { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public bool isSelect { get; set; }

        public ucBtnStep()
        {
            InitializeComponent();
        }

        private void ucBtnStep_Paint(object sender, PaintEventArgs e)
        {
            this.ForeColor = color;
            this.BackColor = BGColor;
            txtSTT.Text = STT.ToString();
            txtTitle.Text = Title;
            if (isSelect) panelSelect.BackColor = ThamSoHeThong.Mau_LuaChon;
            //txtHeader.Text = Header;
        }
    }
}
