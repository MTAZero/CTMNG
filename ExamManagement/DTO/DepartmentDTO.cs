using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int Level { get; set; }
        public int Status { get; set; }
        public int DepartmentIDParent { get; set; }

        /**
         * Constructor
         * Phong ban
         */
        public DepartmentDTO() { }

        public DepartmentDTO(DataRow row)
        {
            DepartmentID = (int)row["DepartmentID"];
            DepartmentCode = (string)row["DepartmentCode"];
            DepartmentName = (string)row["DepartmentName"];
            Level = (int)row["Level"];
            Status = (int)row["Status"];
            
            try
            {
                DepartmentIDParent = (int)row["DepartmentIDParent"];
            }
            catch
            {
                DepartmentIDParent = 0;
            }
        }
    }
}
