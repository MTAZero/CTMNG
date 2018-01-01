using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class SubjectDAO
    {
        public static List<SubjectDTO> DanhSach(string timkiem)
        {
            List<SubjectDTO> ans = new List<SubjectDTO>();
            DataTable dt = new DataTable();

            string query = "SELECT * FROM SUBJECTS WHERE STATUS = 1  AND SubjectName like '%'+ @TimKiem +'%'";
            dt = DAO.SqlServerHelper.ExecuteQuery(query, new object[] { timkiem });

            foreach (DataRow row in dt.Rows)
            {
                SubjectDTO monhoc = new SubjectDTO(row);
                ans.Add(monhoc);
            }

            return ans;
        }

        public static List<SubjectDTO> DanhSach()
        {
            List<SubjectDTO> ans = new List<SubjectDTO>();
            DataTable dt = new DataTable();

            string query = "SELECT * FROM SUBJECTS WHERE STATUS = 1";
            dt = DAO.SqlServerHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                SubjectDTO monhoc = new SubjectDTO(row);
                ans.Add(monhoc);
            }

            return ans;
        }

        public static void Sua(SubjectDTO monhoc)
        {
            string query = "UPDATE SUBJECTS SET SubjectCode = @SubjectCode , SubjectName = @SubjectName , Status = @Status , DepartmentID = @DepartmentID "+
                           "WHERE SubjectID = @SubjectID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { monhoc.SubjectCode, monhoc.SubjectName, monhoc.Status, monhoc.DepartmentID, monhoc.SubjectID });
        }

        public static void Xoa(SubjectDTO monhoc)
        {
            string query = "UPDATE SUBJECTS SET STATUS = 0 WHERE SubjectID = @SubjectID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { monhoc.SubjectID });
        }

        public static void Them(SubjectDTO monhoc)
        {
            string query = "INSERT INTO SUBJECTS(SubjectCode, SubjectName, Status, DepartmentID) " +
                           "VALUES( @SubjectCode , @SubjectName , @Status , @DepartmentID )";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { monhoc.SubjectCode, monhoc.SubjectName, monhoc.Status, monhoc.DepartmentID });
        }

        public static bool KiemTraMa(string SubjectCode)
        {
            string query = "SELECT COUNT(*) FROM SUBJECTS WHERE SubjectCode = @SubjectCode";
            int cnt = (int)DAO.SqlServerHelper.ExecuteScalar(query, new object[] { SubjectCode, SubjectCode });
            return cnt == 0;
        }
    }
}
