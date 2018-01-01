namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEST_DETAILS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEST_DETAILS()
        {
            ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
        }

        [Key]
        public int TestDetailID { get; set; }

        public string RandomAnswer { get; set; }

        public int NumberIndex { get; set; }

        public double Score { get; set; }

        public int Status { get; set; }

        public int TestID { get; set; }

        public int QuestionID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }

        public virtual QUESTION QUESTION { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
