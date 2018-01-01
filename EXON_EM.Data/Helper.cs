using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON_EM.Data
{
    public static class Helper
    {
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }

        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }

        public static string TrangThaiKiThi(int status)
        {
            if (status == 0) return "Mới tạo và chưa phê duyệt";
            if (status == 1) return "Đã phê duyệt và chưa đăng ký";
            if (status == 2) return "Đã hủy";
            if (status == 3) return "Đã hoàn thành";
            if (status == 4) return "Đã đăng ký và chưa xếp lịch";
            if (status == 5) return "Đã xếp lịch và chưa làm đề";
            if (status == 6) return "Đã làm đề và chưa chyển CSDL";
            if (status == 7) return "Đã chuyển CSDL và đang thi";
            return "";
        }
    }
}
