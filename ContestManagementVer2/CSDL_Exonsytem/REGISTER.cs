namespace ContestManagementVer2.CSDL_Exonsytem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REGISTERS")]
    public partial class REGISTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REGISTER()
        {
            CONTESTANTS = new HashSet<CONTESTANT>();
            RECEIPTS = new HashSet<RECEIPT>();
            REGISTERS_SUBJECTS = new HashSet<REGISTERS_SUBJECTS>();
        }

        public int RegisterID { get; set; }

        [StringLength(20)]
        public string StudentCode { get; set; }

        public string FullName { get; set; }

        public int? DOB { get; set; }

        [StringLength(100)]
        public string Ethnic { get; set; }

        public string PlaceOfBirth { get; set; }

        public string HighSchool { get; set; }

        public int? Sex { get; set; }

        [StringLength(12)]
        public string IdentityCardNumber { get; set; }

        [StringLength(200)]
        public string Unit { get; set; }

        public string CurrentAddress { get; set; }

        public int RegisteredDate { get; set; }

        public int? RegisteredType { get; set; }

        public int? TrainingSystem { get; set; }

        public int? LevelsOfTraining { get; set; }

        public byte[] Image { get; set; }

        public int Status { get; set; }

        public int ContestID { get; set; }

        public int? ContestantTypeID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string TelephoneNumber { get; set; }

        public virtual CONTESTANT_TYPES CONTESTANT_TYPES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANT> CONTESTANTS { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEIPT> RECEIPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTERS_SUBJECTS> REGISTERS_SUBJECTS { get; set; }
    }
}
