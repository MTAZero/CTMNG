using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class ReminderDTO
    {
        public int ReminderID { get; set; }
        public string ReminderContent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int SendStaffID { get; set; }
        public int ReceiveStaffID { get; set; }

        public ReminderDTO()
        {

        }

        public ReminderDTO(DataRow row)
        {
            ReminderID = (int)row["ReminderID"];
            ReminderContent = (string)row["ReminderContent"];
            StartDate = Helper.ConvertUnixToDateTime((int)row["StartDate"]);
            EndDate = Helper.ConvertUnixToDateTime((int)row["EndDate"]);
            Status = (int)row["Status"];
            SendStaffID = (int)row["SendStaffID"];
            ReceiveStaffID = (int)row["ReceiveStaffID"];
        }
    }
}
