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
    
    public partial class POSITION
    {
        public POSITION()
        {
            this.STAFFS_POSITIONS = new HashSet<STAFFS_POSITIONS>();
        }
    
        public int PositionID { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public Nullable<int> Permission { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ICollection<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }
    }
}