using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RBACProject.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(): base()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
