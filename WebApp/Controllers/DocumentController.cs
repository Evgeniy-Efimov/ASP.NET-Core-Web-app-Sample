using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public IActionResult Index(SearchViewModel searchModel = null)
        {
            return View("Search", GetSearchVM(searchModel));
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel searchModel = null)
        {
            searchModel = GetSearchVM(searchModel);
            return View(searchModel);
        }

        private SearchViewModel GetSearchVM(SearchViewModel searchModel = null)
        {
            searchModel.Documents = _documentService.GetDocuments(searchModel);
            searchModel.DocumentTypes = _documentService.GetDocumentTypes(searchModel.DocumentTypeId);
            return searchModel;
        }
    }
}
