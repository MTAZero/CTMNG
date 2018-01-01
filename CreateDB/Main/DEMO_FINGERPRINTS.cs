namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DEMO_FINGERPRINTS
    {
        [Key]
        public int FingerprintID { get; set; }

        public byte[] FingerprintImage { get; set; }
    }
}
