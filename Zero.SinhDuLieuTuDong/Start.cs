using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.SinhDuLieuTuDong
{
    public static class Start
    {

        public static void SinhDuLieuNgauNhien(int ContestID)
        {
            FrmMain form = new FrmMain(ContestID);
            form.ShowDialog();
        }

    }
}
