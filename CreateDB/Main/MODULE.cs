namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MODULES")]
    public partial class MODULE
    {
        public int ModuleID { get; set; }

        [Required]
        [StringLength(10)]
        public string ModuleCode { get; set; }

        public int SchoolYear { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int SubjectID { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }
    }
}
