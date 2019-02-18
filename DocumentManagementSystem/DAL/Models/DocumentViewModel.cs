using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.DAL.Models
{
    public class DocumentViewModel
    {
        [StringLength(20)]
        public string categoryName { get; set; }

        [StringLength(50)]
        public string content { get; set; }

        [StringLength(50)]
        public string url { get; set; }
    }
}