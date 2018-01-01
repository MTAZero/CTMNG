using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestManagementVer2
{
    public class ThamSoHeThong
    {
        public enum StatusKiThi
        {
            DaLapKeHoach = 0,
            DaPheDuyet = 1,
            DaHuy = 2,
            DaHoanThanh = 3,
            DaDangKy = 4,
            DaXepLich = 5,
            DaLamDe = 6,
            DaChuyenCSDL = 7
        }

        public static Color DaHoanThanh = Color.Green; //Color.FromArgb(192, 255, 192);
        public static Color DangThucHien = Color.Orange; // Color.FromArgb(255, 224, 192);
        public static Color ChuaThucHien = Color.Gray; //Color.FromArgb(255, 255, 255);
    }
}
