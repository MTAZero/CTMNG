using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON_ExamManagement
{
    public static class ThamSoHeThong
    {
        // Màu sắc cho menu các bước trong lập kế hoạch thi
        public static Color Mau_DaHoanThanh = Color.Green;
        public static Color Mau_DangThucHien = Color.DarkOrange;
        public static Color Mau_ChuaHoanThanh = Color.Gray;
        public static Color Mau_LuaChon = Color.FromArgb(255, 192, 128);
        
        // mau cua cuoc thi
        public static Color getMauCuocThi(int status)
        {
            switch (status)
            {
                case 0: return Color.White;
                case 1: return Color.White;
                case 2: return Color.Red;
                case 3: return Color.Green;
                case 4: return Color.White;
                case 5: return Color.White;
                case 6: return Color.White;
                case 7: return Color.LightGreen;

            }

            return Color.LightBlue;
        }
    }
}
