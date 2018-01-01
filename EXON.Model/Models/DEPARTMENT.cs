namespace EXON.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTMENTS")]
    public partial class DEPARTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT()
        {
            DEPARTMENTS1 = new HashSet<DEPARTMENT>();
            STAFFS = new HashSet<STAFF>();
            SUBJECTS = new HashSet<SUBJECT>();
        }

        public int DepartmentID { get; set; }

        [Required]
        [StringLength(10)]
        public string DepartmentCode { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public int Level { get; set; }

        public int Status { get; set; }

        public int? DepartmentIDParent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS1 { get; set; }

        public virtual DEPARTMENT DEPARTMENT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAFF> STAFFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBJECT> SUBJECTS { get; set; }
    }
}
