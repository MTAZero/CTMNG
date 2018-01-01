using EXON_ExamManagement.UC.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON_ExamManagement.UC.LapKeHoachKiThi
{
    public static class ucLapKeHoachThiHelper
    {
        public static List<UserControl> getListUserControl(int trangthai)
        {
            List<UserControl> ans = new List<UserControl>();

            for(int i=1; i<=5; i++)
            {
                ucBtnStep uc = new ucBtnStep();

                uc.STT = i;
                uc.Header = "";
                uc.color = System.Drawing.Color.White;

               
                if (i == trangthai)
                {
                    uc.BGColor = ThamSoHeThong.Mau_DangThucHien;
                    uc.isSelect = true;
                }
                else
                {
                    uc.isSelect = false;
                    if (i < trangthai) uc.BGColor = ThamSoHeThong.Mau_DaHoanThanh;
                    if (i > trangthai) uc.BGColor = ThamSoHeThong.Mau_ChuaHoanThanh;
                }
                

                switch (i)
                {
                    case 1: uc.Title = "THÔNG TIN KÌ THI"; break;
                    case 2: uc.Title = "MÔN THI"; break;
                    case 3: uc.Title = "CA THI"; break;
                    case 4: uc.Title = "ĐỊA ĐIỂM THI"; break;
                    case 5: uc.Title = "HỘI ĐỒNG THI"; break;
                }

                ans.Add(uc);
            }

            return ans;
        }
    }
}
