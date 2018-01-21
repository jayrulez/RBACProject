using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RBACProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
