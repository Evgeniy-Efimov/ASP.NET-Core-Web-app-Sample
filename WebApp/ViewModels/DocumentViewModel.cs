using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace WebApp.ViewModels
{
    public class DocumentViewModel
    {
        [Display(Name = "Registration number")]
        public string RegNumber { get; set; }

        [Display(Name = "Bar code")]
        public string BarCode { get; set; }

        [Display(Name = "Registration date")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Type")]
        public string DocumentType { get; set; }
    }
}
