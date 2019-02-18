namespace DocumentManagementSystem.DAL.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentView")]
    public partial class DocumentView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int documentId { get; set; }

        [StringLength(20)]
        public string categoryName { get; set; }

        [StringLength(50)]
        public string content { get; set; }

        [StringLength(50)]
        public string url { get; set; }
    }
}
