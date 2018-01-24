using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBACProject.Filters.Attributes;
using RBACProject.Models;

namespace RBACProject.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class RolesController : Controller
    {
        [TypeFilter(typeof(HasPermissionAttribute), Arguments = new object[] { PermissionList.ViewRoles })]
        public IActionResult Index()
        {
            return View();
        }
    }
}