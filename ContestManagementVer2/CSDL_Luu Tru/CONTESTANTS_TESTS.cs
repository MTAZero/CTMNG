namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_TESTS
    {
        [Key]
        public int ContestantTestID { get; set; }

        public int Status { get; set; }

        public int ContestantShiftID { get; set; }

        public int TestID { get; set; }
    }
}
