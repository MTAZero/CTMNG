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
    
    public partial class ROOMDIAGRAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOMDIAGRAM()
        {
            this.CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
        }
    
        public int RoomDiagramID { get; set; }
        public string ComputerCode { get; set; }
        public string ComputerName { get; set; }
        public string ClientIP { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public Nullable<int> RoomTestID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }
        public virtual ROOMTEST ROOMTEST { get; set; }
    }
}