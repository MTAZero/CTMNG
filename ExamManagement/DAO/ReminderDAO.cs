using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class ReminderDAO
    {
        public static List<ReminderDTO> DanhSachNhacNho()
        {
            List<ReminderDTO> ans = new List<ReminderDTO>();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM REMINDERS WHERE STATUS = 1";
            dt = DAO.SqlServerHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                ReminderDTO a = new ReminderDTO(row);
                ans.Add(a);
            }
            return ans;
        }
    }
}
