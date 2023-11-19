using System.Collections.Generic;

namespace WebApp.Models
{
    public class DocumentType : BaseCatalogEntity
    {
        public virtual ICollection<Document> Documents { get; set; }
    }
}
