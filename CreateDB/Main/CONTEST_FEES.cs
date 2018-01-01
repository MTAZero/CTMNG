namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTEST_FEES
    {
        [Key]
        public int ContestFee { get; set; }

        public double? Cost { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        public int? Year { get; set; }

        public int Status { get; set; }

        public int? FreeType { get; set; }

        public int? ContestID { get; set; }

        public virtual CONTEST CONTEST { get; set; }
    }
}
