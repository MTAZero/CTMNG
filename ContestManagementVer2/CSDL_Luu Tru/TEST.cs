namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TESTS")]
    public partial class TEST
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestID { get; set; }

        public int Status { get; set; }

        public int BagOfTestID { get; set; }

        public int SubjectID { get; set; }
    }
}
