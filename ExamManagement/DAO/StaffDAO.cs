using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class StaffDAO
    {
        public static DataTable DanhSachCanBo()
        {
            string query = "SELECT * FROM STAFFS WHERE STATUS = 1";
            return DAO.SqlServerHelper.ExecuteQuery(query);
        }

        /// <summary>
        ///  danh sách theo từ tìm kiếm
        /// </summary>
        /// <returns></returns>
        public static List<StaffDTO> DanhSachCanBo(string timkiem)
        {
            string query = "SELECT * FROM STAFFS WHERE STATUS = 1 AND FullName like '%'+ @TimKiem +'%'";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query, new object[] { timkiem });

            List<StaffDTO> ans = new List<StaffDTO>();

            foreach (DataRow row in dt.Rows)
            {
                StaffDTO a = new StaffDTO(row);
                ans.Add(a);
            }

            return ans;
        }

        public static List<StaffDTO> DanhSachCanBoStaffDTO()
        {
            string query = "SELECT * FROM STAFFS WHERE STATUS = 1";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query);

            List<StaffDTO> ans = new List<StaffDTO>();

            foreach (DataRow row in dt.Rows)
            {
                StaffDTO a = new StaffDTO(row);
                ans.Add(a);
            }

            return ans;
        }

        public static void Sua(StaffDTO canbo)
        {
            string query = "UPDATE STAFFS " +
                           "SET Username = @Username , Password = @Password , FullName = @Fullname , DOB = @DOB , Sex = @Sex , " +
                           "IdentityCardnumber = @IdentityCardnumber , AcademicRank = @AcademicRank , Degree = @Degree , CurrentAddress = @CurrentAddress , MailAddress = @MailAddress , Status = @Status , DepartmentID = @DepartmentID "+
                           "WHERE StaffID = @StaffID";
            int DOB = Helper.ConvertDateTimeToUnix(canbo.DOB);

            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] {canbo.Username,canbo.Password,canbo.FullName, DOB, canbo.Sex, canbo.IdentityCardNumber, canbo.AcademicRank, canbo.Degree, canbo.CurrentAddress, canbo.MailAddress, canbo.Status, canbo.DepartmentID, canbo.StaffID});
        }

        public static void Xoa(StaffDTO canbo)
        {
            string query = "UPDATE STAFFS SET Status = 0 WHERE StaffID = @StaffID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { canbo.StaffID });
        }

        public static void Them(StaffDTO canbo)
        {
            string query = "INSERT INTO STAFFS(Username, Password, FullName, DOB, Sex, IdentityCardNumber, AcademicRank, Degree, CurrentAddress, MailAddress, Status, DepartmentID) "+
                           "VALUES( @Username , @Password , @FullName , @DOB , @Sex , @IdentityCardNumber , @AcademicRank , @Degree , @CurrentAddress , @MailAddress , @Status , @DepartmentID )";
            int DOB = Helper.ConvertDateTimeToUnix(canbo.DOB);
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { canbo.Username, canbo.Password, canbo.FullName, DOB, canbo.Sex, canbo.IdentityCardNumber, canbo.AcademicRank, canbo.Degree, canbo.CurrentAddress, canbo.MailAddress, canbo.Status, canbo.DepartmentID });
        }

        public static bool KiemTraTenTaiKhoan(string username)
        {
            string query = "SELECT COUNT(*) FROM STAFFS WHERE USERNAME = @USERNAME";
            int dem = (int)DAO.SqlServerHelper.ExecuteScalar(query, new object[]{username});
            return dem == 0;
        }
    }
}
