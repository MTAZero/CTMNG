//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUBQUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBQUESTION()
        {
            this.ANSWERS = new HashSet<ANSWER>();
            this.ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
        }
    
        public int SubQuestionID { get; set; }
        public string SubQuestionContent { get; set; }
        public Nullable<double> Score { get; set; }
        public int QuestionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWER> ANSWERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }
        public virtual QUESTION QUESTION { get; set; }
    }
}
