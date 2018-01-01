namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOMDIAGRAMS")]
    public partial class ROOMDIAGRAM
    {
        public int RoomDiagramID { get; set; }

        [StringLength(50)]
        public string ComputerCode { get; set; }

        [Required]
        public string ComputerName { get; set; }

        [StringLength(25)]
        public string ClientIP { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int? RoomTestID { get; set; }
    }
}
