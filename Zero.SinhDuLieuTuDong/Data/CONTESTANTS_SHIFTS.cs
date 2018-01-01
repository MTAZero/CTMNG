namespace Zero.SinhDuLieuTuDong.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_SHIFTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTESTANTS_SHIFTS()
        {
            CONTESTANTS_TESTS = new HashSet<CONTESTANTS_TESTS>();
            VIOLATIONS_CONTESTANTS = new HashSet<VIOLATIONS_CONTESTANTS>();
        }

        [Key]
        public int ContestantShiftID { get; set; }

        public bool? IsCheckFingerprint { get; set; }

        public int? TimeCheck { get; set; }

        public int Status { get; set; }

        public int ShiftID { get; set; }

        public int ScheduleID { get; set; }

        public int ContestantID { get; set; }

        public int? RoomDiagramID { get; set; }

        public virtual CONTESTANT CONTESTANT { get; set; }

        public virtual DIVISION_SHIFTS DIVISION_SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }

        public virtual ROOMDIAGRAM ROOMDIAGRAM { get; set; }

        public virtual SCHEDULE SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }
    }
}
