using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Document : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string RegNumber { get; set; }

        [Required]
        [MaxLength(75)]
        public string BarCode { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public int DocumentTypeId { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
