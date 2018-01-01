using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class AcountDAO
    {
        public static int DangNhap(string TenDangNhap, string MatKhau)
        {
            string query = "SELECT STAFFID FROM STAFFS WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD";
            object ans = DAO.SqlServerHelper.ExecuteScalar(query, new object[] { TenDangNhap, MatKhau });
            if (ans == null) return 0;
            return (int) ans;
        }

        public static StaffDTO NguoiDung(int StaffID)
        {
            StaffDTO ans = new StaffDTO();

            List<StaffDTO> danhsach = StaffDAO.DanhSachCanBoStaffDTO();
            foreach (StaffDTO staff in danhsach)
            {
                if (staff.StaffID == StaffID) ans = staff;
            }

            return ans;
        }

        public static bool KiemTraQuyen(int StaffID, int PositionID)
        {
            string query = "SELECT COUNT(*) FROM STAFFS_POSITIONS WHERE STAFFID = @StaffID AND POSITIONID = @PositionID";
            int ans = (int)DAO.SqlServerHelper.ExecuteScalar(query, new object[] { StaffID, PositionID });
            return ans > 0;
        }

    }
}
