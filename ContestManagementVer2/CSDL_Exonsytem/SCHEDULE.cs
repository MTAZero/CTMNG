namespace ContestManagementVer2.CSDL_Exonsytem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHEDULES")]
    public partial class SCHEDULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCHEDULE()
        {
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            STRUCTURES = new HashSet<STRUCTURE>();
        }

        public int ScheduleID { get; set; }

        public int TimeOfTest { get; set; }

        public int TimeToSubmit { get; set; }

        public int Status { get; set; }

        public int ContestID { get; set; }

        public int SubjectID { get; set; }

        public int Fee { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public int? ContestTypeID { get; set; }

        public virtual CONTEST_TYPES CONTEST_TYPES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE> STRUCTURES { get; set; }
    }
}
