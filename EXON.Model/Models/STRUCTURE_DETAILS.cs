namespace EXON.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STRUCTURE_DETAILS
    {
        [Key]
        public int StructureDetailID { get; set; }

        public int NumberQuestions { get; set; }

        public int Level { get; set; }

        public double Score { get; set; }

        public int Status { get; set; }

        public int StructureID { get; set; }

        public int TopicID { get; set; }

        public virtual STRUCTURE STRUCTURE { get; set; }

        public virtual TOPIC TOPIC { get; set; }
    }
}
