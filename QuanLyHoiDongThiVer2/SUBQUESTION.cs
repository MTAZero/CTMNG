//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyHoiDongThiVer2
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUBQUESTION
    {
        public SUBQUESTION()
        {
            this.ANSWERS = new HashSet<ANSWER>();
            this.ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
        }
    
        public int SubQuestionID { get; set; }
        public string SubQuestionContent { get; set; }
        public Nullable<double> Score { get; set; }
        public int QuestionID { get; set; }
    
        public virtual ICollection<ANSWER> ANSWERS { get; set; }
        public virtual ICollection<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }
        public virtual QUESTION QUESTION { get; set; }
    }
}
