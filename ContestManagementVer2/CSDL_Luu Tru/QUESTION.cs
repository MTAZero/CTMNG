namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUESTIONS")]
    public partial class QUESTION
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionID { get; set; }

        public string QuestionContent { get; set; }

        public int QuestionFormat { get; set; }

        public int? Level { get; set; }

        public bool IsQuiz { get; set; }

        public bool IsSingleChoice { get; set; }

        public bool IsParagraph { get; set; }

        public bool IsQuestionContent { get; set; }

        public int NumberSubQuestion { get; set; }

        public int NumberAnswer { get; set; }
    }
}
