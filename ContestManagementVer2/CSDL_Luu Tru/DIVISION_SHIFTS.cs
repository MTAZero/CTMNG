namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DIVISION_SHIFTS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DivisionShiftID { get; set; }

        public int Status { get; set; }

        public int ShiftID { get; set; }

        public int RoomTestID { get; set; }

        [StringLength(20)]
        public string Key { get; set; }
    }
}
