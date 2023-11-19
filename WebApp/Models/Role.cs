using System.Collections.Generic;

namespace WebApp.Models
{
    public class Role : BaseCatalogEntity
    {
        public virtual ICollection<User> Users { get; set; }
    }
}
