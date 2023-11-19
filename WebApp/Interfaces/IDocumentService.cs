using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Interfaces
{
    public interface IDocumentService
    {
        public IEnumerable<SelectListItem> GetDocumentTypes(short? documentTypeId);
        public IEnumerable<DocumentViewModel> GetDocuments(SearchViewModel document);
    }
}
