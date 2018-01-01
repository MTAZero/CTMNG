namespace ContestManagementVer2.CSDL_Exonsytem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REGISTERS_SUBJECTS
    {
        [Key]
        public int RegisterSubjectID { get; set; }

        public int Status { get; set; }

        public int RegisterID { get; set; }

        public int SubjectID { get; set; }

        public virtual REGISTER REGISTER { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }
    }
}
