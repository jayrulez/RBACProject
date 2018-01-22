using Microsoft.AspNetCore.Identity;
using RBACProject.Models;

namespace RBACProject.Areas.Admin.Managers
{
    public class ApplicationRoleManager
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationRoleManager(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
    }
}
