namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTESTANTS")]
    public partial class CONTESTANT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContestantID { get; set; }

        [Required]
        [StringLength(20)]
        public string ContestantCode { get; set; }

        public string ContestantType { get; set; }

        [Required]
        public string FullName { get; set; }

        public int? DOB { get; set; }

        [StringLength(100)]
        public string Ethnic { get; set; }

        public string PlaceOfBirth { get; set; }

        public string HighSchool { get; set; }

        public int? Sex { get; set; }

        [StringLength(12)]
        public string IdentityCardNumber { get; set; }

        [StringLength(100)]
        public string Unit { get; set; }

        public string CurrentAddress { get; set; }

        public string TrainingSystem { get; set; }

        [StringLength(20)]
        public string StudentCode { get; set; }

        public byte[] Image { get; set; }

        public int Status { get; set; }
    }
}
