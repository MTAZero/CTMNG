namespace EXON.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STRUCTURES")]
    public partial class STRUCTURE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STRUCTURE()
        {
            STRUCTURE_DETAILS = new HashSet<STRUCTURE_DETAILS>();
        }

        public int StructureID { get; set; }

        public int CreatedDate { get; set; }

        public int Status { get; set; }

        public int ScheduleID { get; set; }

        public int CreatedStaffID { get; set; }

        public virtual SCHEDULE SCHEDULE { get; set; }

        public virtual STAFF STAFF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE_DETAILS> STRUCTURE_DETAILS { get; set; }
    }
}
