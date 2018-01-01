using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralManagement.Common
{
   public class ContestantInformation
    {
        public string IPPORT { get; set; }
        public UserHelper.UserTransformation UserTransfer { get; set; }
        public int LoginStatus { get; set; }
        public int LoginError { get; set; }
        public ContestantInformation() { }
    }
}
