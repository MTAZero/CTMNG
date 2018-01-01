using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class SubjectDTO
    {
        public int SubjectID { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Status { get; set; }
        public int DepartmentID { get; set; }
        public SubjectDTO() { }
        public SubjectDTO(DataRow row)
        {
            SubjectID = (int)row["SubjectID"];
            SubjectCode = (string)row["SubjectCode"];
            SubjectName = (string)row["SubjectName"];
            Status = (int)row["Status"];
            DepartmentID = (int)row["DepartmentID"];
        }
    }
}
