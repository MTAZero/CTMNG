namespace EXON_EM.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANSWERSHEETS")]
    public partial class ANSWERSHEET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANSWERSHEET()
        {
            ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
        }

        public int AnswerSheetID { get; set; }

        public double? TestScores { get; set; }

        public double? EssayPoints { get; set; }

        public int Status { get; set; }

        public int ContestantTestID { get; set; }

        public int? StaffID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }

        public virtual CONTESTANTS_TESTS CONTESTANTS_TESTS { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
