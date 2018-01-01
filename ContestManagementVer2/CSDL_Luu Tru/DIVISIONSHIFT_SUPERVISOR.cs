namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DIVISIONSHIFT_SUPERVISOR
    {
        public int DivisionShift_SupervisorID { get; set; }

        public int? SupervisorID { get; set; }

        public int? DivisionShiftID { get; set; }
    }
}
