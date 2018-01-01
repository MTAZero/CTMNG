namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIOLATIONS_CONTESTANTS
    {
        [Key]
        public int ViolationDetailID { get; set; }

        public int Status { get; set; }

        public int? TimeSave { get; set; }

        public int ViolationID { get; set; }

        public int ContestantShiftID { get; set; }
    }
}
