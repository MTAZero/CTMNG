using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
    public  class RoomDiagrams
    {
        public string   ComputerCode { get; set; }
        public string ComputerName { get; set; }
        public int Status { get; set; }
        public RoomDiagrams () { }
        public RoomDiagrams(string _ComputerCode, string _ComputerName, int _Status)
        {
            ComputerCode = _ComputerCode;
            ComputerName = _ComputerName;
            Status = _Status;
        }
    }
}
