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
    
    public partial class ANSWERSHEET
    {
        public ANSWERSHEET()
        {
            this.ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
        }
    
        public int AnswerSheetID { get; set; }
        public Nullable<double> TestScores { get; set; }
        public Nullable<double> EssayPoints { get; set; }
        public int Status { get; set; }
        public int ContestantTestID { get; set; }
        public Nullable<int> StaffID { get; set; }
    
        public virtual ICollection<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }
        public virtual CONTESTANTS_TESTS CONTESTANTS_TESTS { get; set; }
        public virtual STAFF STAFF { get; set; }
    }
}
