using CL.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralManagement.Supports
{
   public class InfoContestant
    {
        public int ContestantID { get; set; }
        public string ContestantCode { get; set; }
        public string FullName { get; set; }
        public int DOB { get; set; }
        public int Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public string StudentCode { get; set; }
        public int ShiftID { get; set; }
        public string RoomTestName { get; set; }
        public string SubjectName { get; set; }
        public string ComputerName { get; set; }
        public string Port { get; set; }
        public CONTESTANTS_SHIFTS ContestantShift { get; set; }

        public InfoContestant() { }
        public InfoContestant(int contestantID, string contestantCode,string fullName, int dOB, int sex, string identityCardNumber, string studentCode, int shiftID,string roomName, string subjectName, string computerName, string port, CONTESTANTS_SHIFTS contestantShift)
        {                                                                                                                                                                                   
            this.ContestantID = contestantID;
            this.ContestantCode = contestantCode;
            this.FullName = fullName;
            this.DOB = dOB;
            this.IdentityCardNumber = identityCardNumber;
            this.Sex = sex;
            this.StudentCode = studentCode;
            this.ShiftID = shiftID;
            this.RoomTestName = roomName;
            this.SubjectName = subjectName;
            this.ComputerName = computerName;
            this.Port = port;
            this.ContestantShift = contestantShift;
        }

    }
}
