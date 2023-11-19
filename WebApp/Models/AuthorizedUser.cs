using System.Collections.Generic;

namespace WebApp.Models
{
    public class AuthorizedUser
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public IEnumerable<short> RoleIds { get; set; }
    }
}
