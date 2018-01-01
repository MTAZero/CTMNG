namespace ContestManagementVer2.CSDL_Exonsytem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBQUESTIONS")]
    public partial class SUBQUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBQUESTION()
        {
            ANSWERS = new HashSet<ANSWER>();
        }

        public int SubQuestionID { get; set; }

        public string SubQuestionContent { get; set; }

        public int QuestionID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWER> ANSWERS { get; set; }

        public virtual QUESTION QUESTION { get; set; }
    }
}
