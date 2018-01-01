using ContestManagementVer2.CSDL_Exonsytem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestManagementVer2.DAO
{
    public static class Helper
    {
        /// <summary>
        ///  đổi thời gian sang int
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }

        /// <summary>
        /// đổi int sang thời gian
        /// </summary>
        /// <param name="unix"></param>
        /// <returns></returns>
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

        /// Chuyển từ List<T> sang dataTable
        public static DataTable ToDataTable<T>(IList<T> data)// T is any generic type
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static bool CheckContest(CONTEST kithi, ref string Err)
        {
            ExonSystem db = DBService.db;
            DBService.Reload();

            // kiểm tra danh sách môn thi
            int cnt = db.SCHEDULES.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList().Count;
            if (cnt < 1)
            {
                Err = "Kì thi cần ít nhất một môn thi";
                return false;
            }

            // kiểm tra danh sách ca thi
            cnt = db.SHIFTS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList().Count;
            if (cnt < 1)
            {
                Err = "Kì thi cần ít nhất một ca thi";
                return false;
            }

            // kiểm tra địa điểm thi
            cnt = db.LOCATIONS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList().Count;
            if (cnt < 1)
            {
                Err = "Kì thi cần ít nhất một địa điểm thi";
                return false;
            }

            // kiểm tra phòng thi
            cnt = (
                    from diadiem in db.LOCATIONS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList()
                    from phongthi in db.ROOMTESTS.Where(p => p.Status > 0 && p.LocationID == diadiem.LocationID).ToList()
                    select phongthi
                  ).ToList()
                  .Count;
            if (cnt < 1)
            {
                Err = "Kì thi cần ít nhất một phòng thi";
                return false;
            }

            // kiểm tra hội đồng thi
            cnt = db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList().Count;
            if (cnt < 1)
            {
                Err = "Kì thi chưa được phân công hội đồng thi";
                return false;
            }

            return true;
        }


    }
}
