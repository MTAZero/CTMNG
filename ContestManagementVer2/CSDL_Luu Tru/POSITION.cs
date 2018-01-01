namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POSITIONS")]
    public partial class POSITION
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PositionID { get; set; }

        [StringLength(10)]
        public string PositionCode { get; set; }

        public string PositionName { get; set; }

        public int? Permission { get; set; }

        public int? Status { get; set; }
    }
}
