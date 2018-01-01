namespace CreateDB.QuizMain
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
            DIVISIONSHIFT_SUPERVISOR = new HashSet<DIVISIONSHIFT_SUPERVISOR>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DivisionShiftID { get; set; }

        public int Status { get; set; }

        public int ShiftID { get; set; }

        public int RoomTestID { get; set; }

        [StringLength(20)]
        public string Key { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAGOFTEST> BAGOFTESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVISIONSHIFT_SUPERVISOR> DIVISIONSHIFT_SUPERVISOR { get; set; }

        public virtual ROOMTEST ROOMTEST { get; set; }

        public virtual SHIFT SHIFT { get; set; }
    }
}
