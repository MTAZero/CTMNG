using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class ViolationDAO
    {
        public static List<ViolationDTO> DanhSach()
        {
            string query = "SELECT * FROM VIOLATIONS WHERE STATUS = 1";
            DataTable dt = new DataTable();
            dt = DAO.SqlServerHelper.ExecuteQuery(query);

            List<ViolationDTO> ans = new List<ViolationDTO>();
            foreach(DataRow row in dt.Rows){
                ViolationDTO loaivp = new ViolationDTO(row);
                ans.Add(loaivp);
            }            
            
            return ans;
        }

        public static List<ViolationDTO> DanhSach(string timkiem)
        {
            string query = "SELECT * FROM VIOLATIONS WHERE STATUS = 1 AND ViolationName like '%'+ @TimKiem +'%'";
            DataTable dt = new DataTable();
            dt = DAO.SqlServerHelper.ExecuteQuery(query, new object[] { timkiem });

            List<ViolationDTO> ans = new List<ViolationDTO>();
            foreach (DataRow row in dt.Rows)
            {
                ViolationDTO loaivp = new ViolationDTO(row);
                ans.Add(loaivp);
            }

            return ans;
        }

        public static void Xoa(ViolationDTO vipham)
        {
            string query = "UPDATE VIOLATIONS SET Status = 0 WHERE ViolationID = @ViolationID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { vipham.ViolationID });
        }

        public static void Sua(ViolationDTO vipham)
        {
            string query = "UPDATE VIOLATIONS " +
                           "SET ViolationName = @ViolationName , Description = @Descripttion , level = @Level , Status = @Status "+
                           "WHERE ViolationID = @ViolationID ";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { vipham.ViolationName, vipham.Description, vipham.Level, vipham.Status, vipham.ViolationID });
        }

        public static void Them(ViolationDTO vipham)
        {
            string query = "INSERT INTO VIOLATIONS(ViolationName, Description, Level, Status) " +
                           "VALUES( @ViolationName , @Desciption , @Level , @Status )";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { vipham.ViolationName, vipham.Description, vipham.Level, vipham.Status });
        }
    }
}
