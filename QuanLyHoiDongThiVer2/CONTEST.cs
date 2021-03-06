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
    
    public partial class CONTEST
    {
        public CONTEST()
        {
            this.EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            this.LOCATIONS = new HashSet<LOCATION>();
            this.SHIFTS = new HashSet<SHIFT>();
        }
    
        public int ContestID { get; set; }
        public string ContestName { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedDate { get; set; }
        public Nullable<int> EndDate { get; set; }
        public Nullable<int> AcceptedDate { get; set; }
        public Nullable<int> BeginRegistration { get; set; }
        public Nullable<int> EndRegistration { get; set; }
        public Nullable<int> CreatedQuestionStartDate { get; set; }
        public Nullable<int> CreatedQuestionEndDate { get; set; }
        public string SchoolYear { get; set; }
        public int Status { get; set; }
        public Nullable<int> CreatedStaffID { get; set; }
        public Nullable<int> AcceptedStaffID { get; set; }
    
        public virtual ICollection<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }
        public virtual ICollection<LOCATION> LOCATIONS { get; set; }
        public virtual ICollection<SHIFT> SHIFTS { get; set; }
    }
}
