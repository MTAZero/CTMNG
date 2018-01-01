namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIOLATIONS")]
    public partial class VIOLATION
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ViolationID { get; set; }

        [StringLength(100)]
        public string ViolationName { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public int Status { get; set; }
    }
}
