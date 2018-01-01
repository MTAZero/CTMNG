using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class Staffs_PositionsDTO
    {
        public int StaffPositionID { get; set; }
        public int StaffID { get; set; }
        public int PositionID { get; set; }

        public Staffs_PositionsDTO() { }
        public Staffs_PositionsDTO(DataRow row)
        {
            StaffPositionID = (int)row["StaffPositionID"];
            StaffID = (int)row["StaffID"];
            PositionID = (int)row["PositionID"];
        }
    }
}
