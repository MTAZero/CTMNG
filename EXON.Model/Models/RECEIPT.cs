namespace EXON.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RECEIPTS")]
    public partial class RECEIPT
    {
        public int ReceiptID { get; set; }

        public double? Cost { get; set; }

        public int ReceivedDate { get; set; }

        public int RegisteredDate { get; set; }

        public bool ReceiptType { get; set; }

        public int Status { get; set; }

        public int StaffID { get; set; }

        public int RegisterID { get; set; }

        public virtual REGISTER REGISTER { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
