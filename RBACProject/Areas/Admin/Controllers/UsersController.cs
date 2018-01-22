using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RBACProject.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}