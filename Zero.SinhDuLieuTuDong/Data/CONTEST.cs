namespace Zero.SinhDuLieuTuDong.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTESTS")]
    public partial class CONTEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTEST()
        {
            CONTEST_FEES = new HashSet<CONTEST_FEES>();
            EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            LOCATIONS = new HashSet<LOCATION>();
            REGISTERS = new HashSet<REGISTER>();
            SCHEDULES = new HashSet<SCHEDULE>();
            SHIFTS = new HashSet<SHIFT>();
            ORIGINAL_TESTS = new HashSet<ORIGINAL_TESTS>();
        }

        public int ContestID { get; set; }

        public string ContestName { get; set; }

        public string Description { get; set; }

        public int CreatedDate { get; set; }

        public int? EndDate { get; set; }

        public int? AcceptedDate { get; set; }

        public int BeginRegistration { get; set; }

        public int EndRegistration { get; set; }

        public int CreatedQuestionStartDate { get; set; }

        public int CreatedQuestionEndDate { get; set; }

        [StringLength(20)]
        public string SchoolYear { get; set; }

        public int Status { get; set; }

        public int? CreatedStaffID { get; set; }

        public int? AcceptedStaffID { get; set; }

        public int? BeginDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTEST_FEES> CONTEST_FEES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual STAFF STAFF1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCATION> LOCATIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTER> REGISTERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFT> SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORIGINAL_TESTS> ORIGINAL_TESTS { get; set; }
    }
}
