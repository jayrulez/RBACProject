using Microsoft.AspNetCore.Identity;
using RBACProject.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RBACProject.Areas.Admin.Managers
{
    public class ApplicationUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<ApplicationUser> GetUser(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal);
        }

        public Task<List<Permission>> GetPermissions()
        {
            return Task.FromResult(new List<Permission>());
        }
    }
}
