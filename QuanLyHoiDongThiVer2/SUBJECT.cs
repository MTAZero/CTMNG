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
    
    public partial class SUBJECT
    {
        public SUBJECT()
        {
            this.SCHEDULES = new HashSet<SCHEDULE>();
            this.TESTS = new HashSet<TEST>();
        }
    
        public int SubjectID { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<SCHEDULE> SCHEDULES { get; set; }
        public virtual ICollection<TEST> TESTS { get; set; }
    }
}
