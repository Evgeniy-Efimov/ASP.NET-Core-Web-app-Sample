using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using WebApp.Helpers;

namespace WebApp.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Registration number")]
        public string RegNumber { get; set; }

        [Display(Name = "Bar code")]
        public string BarCode { get; set; }

        [Display(Name = "Registration date")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Document type")]
        public short? DocumentTypeId { get; set; }

        public IEnumerable<SelectListItem> DocumentTypes { get; set; }

        public IEnumerable<DocumentViewModel> Documents { get; set; }

        public int TotalPages { get; set; }

        public int Page { get; set; }

        public SearchViewModel()
        {
            Page = SettingHelper.PaginationSetting.DefaultPage;
        }
    }
}
