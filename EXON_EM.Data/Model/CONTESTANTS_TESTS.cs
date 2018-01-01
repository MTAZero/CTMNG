namespace EXON_EM.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_TESTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTESTANTS_TESTS()
        {
            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
        }

        [Key]
        public int ContestantTestID { get; set; }

        public int Status { get; set; }

        public int ContestantShiftID { get; set; }

        public int TestID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }

        public virtual CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
