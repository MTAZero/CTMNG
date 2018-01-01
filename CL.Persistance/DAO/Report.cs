using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CL.Persistance.DAO
{
    public partial class Report
    {
        public string ContestantCode { get; set; }
        public string FullName { get; set; }
        public int DOB { get; set; }
        public int Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public Nullable<double> TestScores { get; set; }

    }
}
