namespace ContestManagementVer2.CSDL_Exonsytem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_SUBJECTS
    {
        [Key]
        public int ContestantSubjectID { get; set; }

        public int Status { get; set; }

        public int? SubjectID { get; set; }

        public int? ContestantID { get; set; }

        public virtual CONTESTANT CONTESTANT { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }
    }
}
