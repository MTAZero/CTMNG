using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class StaffDTO
    {
        public int StaffID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public int Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public string AcademicRank { get; set; }
        public string Degree { get; set; }
        public string CurrentAddress { get; set; }
        public string MailAddress { get; set; }
        public int Status { get; set; }
        public int DepartmentID { get; set; }
        public string DOB2 { get; set; }
        //public int PositionID { get; set; }
        public StaffDTO(DataRow row)
        {
            StaffID = (int)row["StaffID"];
            Username = (string)row["Username"];
            Password = (string)row["Password"];
            FullName = (string)row["FullName"];
            DOB = Helper.ConvertUnixToDateTime((int)row["DOB"]);
            Sex = (int)row["Sex"];
            IdentityCardNumber = (string)row["IdentityCardNumber"];

            try { AcademicRank = (string)row["AcademicRank"]; }
            catch { AcademicRank = ""; }

            try { Degree = (string)row["Degree"]; }
            catch { Degree = ""; }

            try { CurrentAddress = (string)row["CurrentAddress"]; }
            catch { CurrentAddress = ""; }

            try { MailAddress = (string)row["MailAddress"]; }
            catch { MailAddress = ""; }

            Status = (int)row["Status"];
            //PositionID = (int)row["PositionID"];
            DepartmentID = (int)row["DepartmentID"];
            DOB2 = DOB.ToString("dd/MM/yyyy");
        }

        public StaffDTO()
        {

        }

    }
}
