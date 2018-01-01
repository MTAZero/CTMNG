namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBJECTS")]
    public partial class SUBJECT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }

        [StringLength(10)]
        public string SubjectCode { get; set; }

        [Required]
        public string SubjectName { get; set; }

        public int Status { get; set; }
    }
}
