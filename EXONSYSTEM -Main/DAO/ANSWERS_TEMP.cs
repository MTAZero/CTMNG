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
    
    public partial class ANSWERS_TEMP
    {
        public int AnswerID { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
        public int SubQuestionID { get; set; }
        public Nullable<int> SubQuestionTempID { get; set; }
        public int DivisionShiftID { get; set; }
        public int AnswerTempID { get; set; }
    }
}
