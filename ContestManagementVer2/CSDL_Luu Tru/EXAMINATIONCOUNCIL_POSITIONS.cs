namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EXAMINATIONCOUNCIL_POSITIONS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExaminationCouncil_PositionID { get; set; }

        [Required]
        [StringLength(10)]
        public string ExaminationCouncil_PositionCode { get; set; }

        public string ExaminationCouncil_PositionName { get; set; }

        public int? Permission { get; set; }

        public int Status { get; set; }
    }
}
