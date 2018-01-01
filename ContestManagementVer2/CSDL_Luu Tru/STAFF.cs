namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STAFFS")]
    public partial class STAFF
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffID { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public int? DOB { get; set; }

        public int? Sex { get; set; }

        [StringLength(12)]
        public string IdentityCardNumber { get; set; }

        [StringLength(100)]
        public string AcademicRank { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        public int Status { get; set; }
    }
}
