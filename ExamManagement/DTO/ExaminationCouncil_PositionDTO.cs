using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class ExaminationCouncil_PositionDTO
    {
        public int ExaminationCouncil_PositionID { get; set; }
        public string ExaminationCouncil_PositionCode { get; set; }
        public string ExaminationCouncil_PositionName { get; set; }
        public int Permission { get; set; }
        public int Status { get; set; }

        /**
         * Constructor
         * Phong ban
         */
        public ExaminationCouncil_PositionDTO() { }

        public ExaminationCouncil_PositionDTO(DataRow row)
        {
            ExaminationCouncil_PositionID = (int)row["ExaminationCouncil_PositionID"];
            ExaminationCouncil_PositionCode = (string)row["ExaminationCouncil_PositionCode"];
            ExaminationCouncil_PositionName = (string)row["ExaminationCouncil_PositionName"];
            Permission = (int)row["Permission"];
            Status = (int)row["Status"];
        }
    }
}
