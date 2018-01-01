namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHEDULES")]
    public partial class SCHEDULE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleID { get; set; }

        public int TimeOfTest { get; set; }

        public int TimeToSubmit { get; set; }

        public int Status { get; set; }

        public int? ContestID { get; set; }

        public string ContestTypeName { get; set; }

        public int SubjectID { get; set; }
    }
}
