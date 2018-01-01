namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBQUESTIONS")]
    public partial class SUBQUESTION
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubQuestionID { get; set; }

        public string SubQuestionContent { get; set; }

        public double? Score { get; set; }

        public int QuestionID { get; set; }
    }
}
