using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class ExaminationCouncil_PositionDAO
    {
        public static List<ExaminationCouncil_PositionDTO> DanhSach()
        {
            string query = "select * from ExaminationCouncil_Positions WHERE STATUS = 1";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query);
            List<ExaminationCouncil_PositionDTO> ans = new List<ExaminationCouncil_PositionDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ExaminationCouncil_PositionDTO tg = new ExaminationCouncil_PositionDTO(row);
                ans.Add(tg);
            }

            return ans;
        }

        public static List<ExaminationCouncil_PositionDTO> DanhSach(string timkiem)
        {
            string query = "select * from ExaminationCouncil_Positions WHERE STATUS = 1 AND ExaminationCouncil_PositionName like '%'+ @TimKiem +'%'";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query, new object[] { timkiem });
            List<ExaminationCouncil_PositionDTO> ans = new List<ExaminationCouncil_PositionDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ExaminationCouncil_PositionDTO tg = new ExaminationCouncil_PositionDTO(row);
                ans.Add(tg);
            }

            return ans;
        }

        public static void Xoa(ExaminationCouncil_PositionDTO tg)
        {
            string query = "UPDATE ExaminationCouncil_Positions SET STATUS = 0 WHERE ExaminationCouncil_PositionID = @ExaminationCouncil_PositionID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.ExaminationCouncil_PositionID });
        }

        public static void Them(ExaminationCouncil_PositionDTO tg)
        {
            string query = "INSERT INTO ExaminationCouncil_Positions(ExaminationCouncil_PositionCode , ExaminationCouncil_PositionName, Permission, Status) VALUES( @ExaminationCouncil_PositionCode , @PositionName , @Permission , 1 )";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.ExaminationCouncil_PositionCode, tg.ExaminationCouncil_PositionName, tg.Permission });
        }

        public static void Sua(ExaminationCouncil_PositionDTO tg)
        {
            string query = "UPDATE ExaminationCouncil_Positions SET ExaminationCouncil_PositionCode = @ExaminationCouncil_PositionCode , ExaminationCouncil_PositionName = @ExaminationCouncil_PositionName , Permission = @Permistion WHERE ExaminationCouncil_PositionID = @ExaminationCouncil_PositionID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { tg.ExaminationCouncil_PositionCode, tg.ExaminationCouncil_PositionName, tg.Permission, tg.ExaminationCouncil_PositionID });
        }

        public static bool KiemTraMa(string ma)
        {
            string query = "SELECT COUNT(*) FROM ExaminationCouncil_Positions WHERE ExaminationCouncil_PositionCode = @Ma";
            int cnt = (int)DAO.SqlServerHelper.ExecuteScalar(query, new object[] { ma });
            return cnt == 0;
        }
    }
}
