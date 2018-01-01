namespace ContestManagementVer2.CSDL_Exonsytem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORIGINAL_TEST_DETAILS
    {
        [Key]
        public int OriginalTestDetailID { get; set; }

        public int NumberIndex { get; set; }

        public int Status { get; set; }

        public int OriginalTestID { get; set; }

        public int QuestionID { get; set; }

        public virtual ORIGINAL_TESTS ORIGINAL_TESTS { get; set; }

        public virtual QUESTION QUESTION { get; set; }
    }
}
