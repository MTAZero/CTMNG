namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHIFTS")]
    public partial class SHIFT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShiftID { get; set; }

        [StringLength(100)]
        public string ShiftName { get; set; }

        public int ShiftDate { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int Status { get; set; }

        public int? ContestID { get; set; }
    }
}
