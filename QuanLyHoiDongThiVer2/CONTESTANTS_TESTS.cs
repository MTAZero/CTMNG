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
    
    public partial class CONTESTANTS_TESTS
    {
        public CONTESTANTS_TESTS()
        {
            this.ANSWERSHEETS = new HashSet<ANSWERSHEET>();
        }
    
        public int ContestantTestID { get; set; }
        public int Status { get; set; }
        public int ContestantShiftID { get; set; }
        public int TestID { get; set; }
    
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }
        public virtual CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS { get; set; }
        public virtual TEST TEST { get; set; }
    }
}
