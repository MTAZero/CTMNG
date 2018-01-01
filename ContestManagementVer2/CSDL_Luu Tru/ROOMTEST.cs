namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOMTESTS")]
    public partial class ROOMTEST
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomTestID { get; set; }

        [StringLength(100)]
        public string RoomTestName { get; set; }

        public int MaxSeatMount { get; set; }

        public int? MaxSupervisor { get; set; }

        public int Status { get; set; }

        public int LocationID { get; set; }
    }
}
