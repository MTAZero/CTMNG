namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTESTANTS")]
    public partial class CONTESTANT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTESTANT()
        {
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            CONTESTANTS_SUBJECTS = new HashSet<CONTESTANTS_SUBJECTS>();
            FINGERPRINTS = new HashSet<FINGERPRINT>();
        }

        public int ContestantID { get; set; }

        [Required]
        [StringLength(20)]
        public string ContestantCode { get; set; }

        public int Status { get; set; }

        public int RegisterID { get; set; }

        public virtual REGISTER REGISTER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SUBJECTS> CONTESTANTS_SUBJECTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FINGERPRINT> FINGERPRINTS { get; set; }
    }
}
