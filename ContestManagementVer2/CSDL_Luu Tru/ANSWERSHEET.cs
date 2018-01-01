namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANSWERSHEETS")]
    public partial class ANSWERSHEET
    {
        public int AnswerSheetID { get; set; }

        public double? TestScores { get; set; }

        public double? EssayPoints { get; set; }

        public int Status { get; set; }

        public int ContestantTestID { get; set; }

        public int? StaffID { get; set; }
    }
}
