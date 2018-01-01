namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STAFFS_POSITIONS
    {
        [Key]
        public int StaffPositionID { get; set; }

        public int StaffID { get; set; }

        public int PositionID { get; set; }
    }
}
