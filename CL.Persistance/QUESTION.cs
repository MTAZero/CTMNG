//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CL.Persistance
{
    using System;
    using System.Collections.Generic;
    
    public partial class QUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUESTION()
        {
            this.SUBQUESTIONS = new HashSet<SUBQUESTION>();
            this.TEST_DETAILS = new HashSet<TEST_DETAILS>();
        }
    
        public int QuestionID { get; set; }
        public string QuestionContent { get; set; }
        public int QuestionFormat { get; set; }
        public Nullable<int> Level { get; set; }
        public bool IsQuiz { get; set; }
        public bool IsSingleChoice { get; set; }
        public bool IsParagraph { get; set; }
        public bool IsQuestionContent { get; set; }
        public int NumberSubQuestion { get; set; }
        public int NumberAnswer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBQUESTION> SUBQUESTIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST_DETAILS> TEST_DETAILS { get; set; }
    }
}
