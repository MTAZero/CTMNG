namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_SHIFTS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContestantShiftID { get; set; }

        public int Status { get; set; }

        public int? IsCheckFingerprint { get; set; }

        public int? TimeCheck { get; set; }

        public int? TimeStarted { get; set; }

        public int? TimeWorked { get; set; }

        public int DivisionShiftID { get; set; }

        public int ScheduleID { get; set; }

        public int ContestantID { get; set; }

        public int? RoomDiagramID { get; set; }
    }
}
