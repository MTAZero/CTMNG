using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class Staffs_PositionDAO
    {
        public static List<ExamManagement.DTO.Staffs_PositionsDTO> DanhSach()
        {
            List<Staffs_PositionsDTO> ans = new List<Staffs_PositionsDTO>();
            string query = "SELECT * FROM STAFFS_POSITIONS";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Staffs_PositionsDTO tg = new Staffs_PositionsDTO(row);
                ans.Add(tg);
            }

            return ans;
        }

        public static void Them(Staffs_PositionsDTO tg){
            string query = "INSERT INTO STAFFS_POSITIONS(StaffID, PositionID) VALUES( @StaffID , @PositionID )";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.StaffID, tg.PositionID });
        }

        public static void Xoa(Staffs_PositionsDTO tg){
            string query = "DELETE FROM STAFFS_POSITIONS WHERE StaffPositionID = @StaffPositionID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.StaffPositionID });
        }
    }
}
