namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REMINDERS")]
    public partial class REMINDER
    {
        public int ReminderID { get; set; }

        public string ReminderContent { get; set; }

        public int? StartDate { get; set; }

        public int? EndDate { get; set; }

        public int Status { get; set; }

        public int SendStaffID { get; set; }

        public int ReceiveStaffID { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual STAFF STAFF1 { get; set; }
    }
}
