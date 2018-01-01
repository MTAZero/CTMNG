using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public class DepartmentDAO
    {
        public static List<DepartmentDTO> DanhSachDonVi()
        {
            string query = "select * from DEPARTMENTS WHERE STATUS = 1";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query);

            List<DepartmentDTO> ans = new List<DepartmentDTO>();

            foreach (DataRow row in dt.Rows)
            {
                DepartmentDTO tg = new DepartmentDTO(row);
                ans.Add(tg);
            }
            
            return ans;
        }

        public static List<DepartmentDTO> DanhSachDonVi(string timkiem)
        {
            string query = "select * from DEPARTMENTS WHERE STATUS = 1 AND DepartmentName like '%'+ @TimKiem +'%'";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query, new object[] { timkiem });
            List<DepartmentDTO> ans = new List<DepartmentDTO>();

            foreach (DataRow row in dt.Rows)
            {
                DepartmentDTO tg = new DepartmentDTO(row);
                ans.Add(tg);
            }

            return ans;
        }

        public static List<DepartmentDTO> DanhSachDonVicbx()
        {
            string query = "select * from DEPARTMENTS WHERE STATUS = 1";
            DataTable dt = DAO.SqlServerHelper.ExecuteQuery(query);

            List<DepartmentDTO> ans = new List<DepartmentDTO>();

            DepartmentDTO dv = new DepartmentDTO();
            dv.DepartmentID = 0;
            dv.DepartmentName = "Không";
            ans.Add(dv);

            foreach (DataRow row in dt.Rows)
            {
                DepartmentDTO tg = new DepartmentDTO(row);
                ans.Add(tg);
            }

            return ans;
        }

        public static void Sua(DepartmentDTO pb)
        {
            if (pb.DepartmentIDParent != 0)
            {
                string query = "UPDATE DEPARTMENTS SET DEPARTMENTCODE = @DEPARTMENTCODE , DEPARTMENTNAME = @DEPARTMENTNAME , LEVEL = @LEVEL , DEPARTMENTIDPARENT = @DEPARTMENTIDPARENT WHERE DEPARTMENTID = @DEPARTMENTID";
                DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { pb.DepartmentCode, pb.DepartmentName, pb.Level, pb.DepartmentIDParent, pb.DepartmentID });
            }
            else
            {
                string query = "UPDATE DEPARTMENTS SET DEPARTMENTCODE = @DEPARTMENTCODE , DEPARTMENTNAME = @DEPARTMENTNAME , LEVEL = @LEVEL WHERE DEPARTMENTID = @DEPARTMENTID";
                DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { pb.DepartmentCode, pb.DepartmentName, pb.Level, pb.DepartmentID });
            }
        }

        public static void Xoa(DepartmentDTO pb)
        {
            string query = "UPDATE DEPARTMENTS SET STATUS = 0 WHERE DEPARTMENTID = @DEPARTMENTID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { pb.DepartmentID });
        }

        public static void ThemDonVi(DepartmentDTO pb)
        {
            if (pb.DepartmentIDParent != 0)
            {
                string query = "INSERT INTO DEPARTMENTS(DEPARTMENTCODE, DEPARTMENTNAME, LEVEL, DEPARTMENTIDPARENT, STATUS) " +
                    "VALUES( @DEPARTMENTCODE , @DEPARTMENTNAME , @LEVEL , @DEPARTMENTIDPARENT , 1 )";
                DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { pb.DepartmentCode, pb.DepartmentName, pb.Level, pb.DepartmentIDParent });
            }
            else
            {
                string query = "INSERT INTO DEPARTMENTS(DEPARTMENTCODE, DEPARTMENTNAME, LEVEL, STATUS) " +
                    "VALUES( @DEPARTMENTCODE , @DEPARTMENTNAME , @LEVEL , 1 )";
                DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { pb.DepartmentCode, pb.DepartmentName, pb.Level });
            }
        }

        public static bool KiemTraMaDonVi(string ma)
        {
            string query = "SELECT COUNT(*) FROM DEPARTMENTS WHERE DEPARTMENTCODE = @Ma";
            int cnt = (int)DAO.SqlServerHelper.ExecuteScalar(query, new object[] { ma });
            return cnt == 0;
        }
    }
}
