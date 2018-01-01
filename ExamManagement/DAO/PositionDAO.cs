using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class PositionDAO
    {
        public static List<PositionDTO> DanhSach()
        {
            string query = "select * from Positions WHERE STATUS = 1";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query);
            List<PositionDTO> ans = new List<PositionDTO>();

            foreach (DataRow row in dt.Rows)
            {
                PositionDTO tg = new PositionDTO(row);
                ans.Add(tg);
            }

            return ans;
        }

        public static List<PositionDTO> DanhSach(string timkiem)
        {
            string query = "select * from Positions WHERE STATUS = 1 AND PositionName like '%'+ @TimKiem +'%'";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query, new object[] { timkiem });
            List<PositionDTO> ans = new List<PositionDTO>();

            foreach (DataRow row in dt.Rows)
            {
                PositionDTO tg = new PositionDTO(row);
                ans.Add(tg);
            }

            return ans;
        }

        public static void Xoa(PositionDTO tg)
        {
            string query = "UPDATE POSITIONS SET STATUS = 0 WHERE PositionID = @PositionID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.PositionID });
        }

        public static void Them(PositionDTO tg)
        {
            string query = "INSERT INTO POSITIONS(PositionCode , PositionName, Permission, Status) VALUES( @PositionCode , @PositionName , @Permission , 1 )";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.PositionCode, tg.PositionName, tg.Permission });
        }

        public static void Sua(PositionDTO tg)
        {
            string query = "UPDATE POSITIONS SET PositionCode = @PositionCode , PositionName = @PositionName , Permission = @Permistion WHERE PositionID = @PositionID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.PositionCode, tg.PositionName, tg.Permission, tg.PositionID });
        }

        public static bool KiemTraMa(string ma)
        {
            string query = "SELECT COUNT(*) FROM Positions WHERE PositionCode = @Ma";
            int cnt = (int)DAO.SqlServerHelper.ExecuteScalar(query, new object[] { ma });
            return cnt == 0;
        }

    }
}
