namespace EXON.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EXAMINATIONCOUNCIL_STAFFS
    {
        [Key]
        public int ExaminationCouncil_StaffID { get; set; }

        public int ContestID { get; set; }

        public int StaffID { get; set; }

        public int ExaminationCouncil_PositionID { get; set; }

        public int LocationID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public int Status { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        public virtual EXAMINATIONCOUNCIL_POSITIONS EXAMINATIONCOUNCIL_POSITIONS { get; set; }

        public virtual LOCATION LOCATION { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
