using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApp.Models
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string UserID { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        public string FullName { get; private set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
