using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class PositionDTO
    {
        public int PositionID { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public int Permission { get; set; }
        public int Status { get; set; }

        /**
         * Constructor
         * Phong ban
         */
        public PositionDTO() { }

        public PositionDTO(DataRow row)
        {
            PositionID = (int)row["PositionID"];
            PositionCode = (string)row["PositionCode"];
            PositionName = (string)row["PositionName"];
            Permission = (int)row["Permission"];
            Status = (int)row["Status"];
        }
    }
}
