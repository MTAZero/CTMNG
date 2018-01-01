namespace Zero.SinhDuLieuTuDong.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ANSWERSHEET_DETAILS
    {
        [Key]
        public int AnswerSheetDetailID { get; set; }

        public int ChoosenAnswer { get; set; }

        public string AnswerContent { get; set; }

        public int? LastTime { get; set; }

        public int Status { get; set; }

        public int AnswerSheetID { get; set; }

        public int TestDetailID { get; set; }

        public virtual ANSWERSHEET ANSWERSHEET { get; set; }

        public virtual TEST_DETAILS TEST_DETAILS { get; set; }
    }
}
