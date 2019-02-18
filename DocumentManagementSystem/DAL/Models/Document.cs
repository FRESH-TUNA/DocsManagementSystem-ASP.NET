namespace DocumentManagementSystem.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int documentId { get; set; }

        public int categoryId { get; set; }

        [StringLength(50)]
        public string content { get; set; }

        [StringLength(50)]
        public string url { get; set; }

        public virtual Category Category { get; set; }
    }
}
