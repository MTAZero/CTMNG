namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORIGINAL_TESTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORIGINAL_TESTS()
        {
            ORIGINAL_TEST_DETAILS = new HashSet<ORIGINAL_TEST_DETAILS>();
        }

        [Key]
        public int OriginalTestID { get; set; }

        public int CreateDate { get; set; }

        public int? AcceptDate { get; set; }

        public int Status { get; set; }

        public int ContestID { get; set; }

        public int SubjectID { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORIGINAL_TEST_DETAILS> ORIGINAL_TEST_DETAILS { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }
    }
}
