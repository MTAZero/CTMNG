namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAGOFTESTS")]
    public partial class BAGOFTEST
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BagOfTestID { get; set; }

        public int NumberOfTest { get; set; }

        public int Status { get; set; }

        public int DivisionShiftID { get; set; }
    }
}
