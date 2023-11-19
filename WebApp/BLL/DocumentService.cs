using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.DAL;
using WebApp.Enums;
using WebApp.Helpers;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.BLL
{
    public class DocumentService : BaseService, IDocumentService 
    {
        private byte PageRowsCount { get { return SettingHelper.PaginationSetting.PageRowsCount; } }

        public DocumentService(DB1DataContext dataContext, IAuthService authService) : base(dataContext, authService)
        {

        }

        public IEnumerable<SelectListItem> GetDocumentTypes(short? documentTypeId)
        {
            CheckPermissionForAction(Roles.User);
            
            return DataContext.DocumentTypes
                .OrderBy(o => o.Name)
                .Select(x => new SelectListItem(x.Name, x.Id.ToString(), x.Id == documentTypeId)); 
        }

        public IEnumerable<DocumentViewModel> GetDocuments(SearchViewModel document)
        {
            CheckPermissionForAction(Roles.User);

            var documents = DataContext.Documents.AsQueryable();

            if (!string.IsNullOrWhiteSpace(document.BarCode))
                documents = documents.Where(x => x.BarCode.Contains(document.BarCode));

            if (!string.IsNullOrWhiteSpace(document.RegNumber))
                documents = documents.Where(x => x.RegNumber.Contains(document.RegNumber));

            if (document.DocumentTypeId != null && document.DocumentTypeId > 0)
                documents = documents.Where(x => x.DocumentTypeId == document.DocumentTypeId);

            if (document.CreationDate != null)
                documents = documents.Where(x => x.CreationDate.Date == document.CreationDate);

            document.TotalPages = CommonHelper.IntegerDivision(documents.Count(), PageRowsCount);

            return documents
                .OrderBy(o => o.RegNumber)
                .Skip((document.Page - 1) * PageRowsCount)
                .Take(PageRowsCount)
                .Select(s => new DocumentViewModel
                {
                    RegNumber = s.RegNumber,
                    BarCode = s.BarCode,
                    CreationDate = s.CreationDate,
                    DocumentType = s.DocumentType.Name
                });
        }
    }
}
