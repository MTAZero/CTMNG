using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralManagement.Common
{
   public  class RoomChange
    {
        public string ContestantID{ get;  set;}
        public string ComputerName { get; set;}
        public string RoomTestName { get; set; }
        public RoomChange (string _ContestanID,string _ComputerName,string _RoomTestName)
        {
            this.ContestantID = _ContestanID;
            this.ComputerName = _ComputerName;
            this.RoomTestName = _RoomTestName;
        }

    }
}
