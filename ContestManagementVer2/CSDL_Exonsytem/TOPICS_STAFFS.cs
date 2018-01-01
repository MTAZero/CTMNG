namespace ContestManagementVer2.CSDL_Exonsytem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TOPICS_STAFFS
    {
        [Key]
        public int TopicStaffID { get; set; }

        public int BeginDate { get; set; }

        public int EndDate { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int TopicID { get; set; }

        public int TaskmasterStaffID { get; set; }

        public int AssignedStaffID { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual STAFF STAFF1 { get; set; }

        public virtual TOPIC TOPIC { get; set; }
    }
}
