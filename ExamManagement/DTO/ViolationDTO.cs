using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class ViolationDTO
    {
        public int ViolationID { get; set; }
        public string ViolationName { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Status { get; set; }

        public ViolationDTO() { }
        public ViolationDTO(DataRow row)
        {
            ViolationID = (int)row["ViolationID"];
            ViolationName = (string)row["ViolationName"];
            Description = (string)row["Description"];
            Level = (int)row["Level"];
            Status = (int)row["Status"];
        }
    }
}
