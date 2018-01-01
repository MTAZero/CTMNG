using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralManagement.Common
{
   public  class CamConfig
    {
        public string RoomName { get; set; }
            
        public string IP { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        //public CamConfig(string _roomname, string _ip, string _port, string _user, string _pass)
        //{
        //    this.RoomName = _roomname;
        //    this.IP = _ip;
        //    this.Port = _port;
        //    this.User = _user;
        //    this.Pass = _pass;
        //}
    }
}
