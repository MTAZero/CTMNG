using EXON_ExamManagement.UC;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON_ExamManagement.GUI
{
    public partial class FrmQuanLyKiThi : MetroForm
    {
        public FrmQuanLyKiThi()
        {
            InitializeComponent();

            Load();
        }

        private void Load()
        {
            ucTrangThaiKiThi uc = new ucTrangThaiKiThi();
            panelTrangThaiCuocThi.Controls.Add(uc);

            ucChucNangQuanLy uc1 = new ucChucNangQuanLy();
            panelMain.Controls.Add(uc1);
        }
    }
}
