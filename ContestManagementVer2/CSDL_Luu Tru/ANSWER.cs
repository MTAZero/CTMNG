namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANSWERS")]
    public partial class ANSWER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnswerID { get; set; }

        public string AnswerContent { get; set; }

        public bool IsCorrect { get; set; }

        public int SubQuestionID { get; set; }
    }
}
