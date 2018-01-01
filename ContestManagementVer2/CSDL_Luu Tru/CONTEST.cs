namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTESTS")]
    public partial class CONTEST
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContestID { get; set; }

        public string ContestName { get; set; }

        public string Description { get; set; }

        public int? CreatedDate { get; set; }

        public int? EndDate { get; set; }

        public int? AcceptedDate { get; set; }

        public int? BeginRegistration { get; set; }

        public int? EndRegistration { get; set; }

        public int? CreatedQuestionStartDate { get; set; }

        public int? CreatedQuestionEndDate { get; set; }

        [StringLength(20)]
        public string SchoolYear { get; set; }

        public int Status { get; set; }

        public int? CreatedStaffID { get; set; }

        public int? AcceptedStaffID { get; set; }
    }
}
