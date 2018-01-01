namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DIVISION_SHIFTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIVISION_SHIFTS()
        {
            BAGOFTESTS = new HashSet<BAGOFTEST>();
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
        }

        [Key]
        public int DivisionShiftID { get; set; }

        public int Status { get; set; }

        public int ShiftID { get; set; }

        public int? SupervisorID { get; set; }

        public int RoomTestID { get; set; }

        [StringLength(20)]
        public string Key { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAGOFTEST> BAGOFTESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        public virtual ROOMTEST ROOMTEST { get; set; }

        public virtual SHIFT SHIFT { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
