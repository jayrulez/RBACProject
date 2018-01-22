using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RBACProject.Areas.Admin.Managers;
using System.Linq;

namespace RBACProject.Filters.Attributes
{
    public class HasPermissionAttribute : ActionFilterAttribute
    {
        private readonly ApplicationUserManager _applicationUserManager;

        private string[] _permissions;

        public HasPermissionAttribute(string permission, ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;

            _permissions = new[] { permission };
        }

        public HasPermissionAttribute(string[] permissions, ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;

            _permissions = permissions;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var user = await _applicationUserManager.GetUser(context.HttpContext.User);

            if(user == null)
            {
                context.Result = new RedirectToActionResult("Home", "Error", null);
            }

            var userPermissions = await _applicationUserManager.GetPermissions();

            foreach(var permission in _permissions)
            {
                if(userPermissions.Any(userPermission => userPermission.Id.Equals(permission)))
                {
                    context.Result = new RedirectToActionResult("Home", "Error", null);
                    break;
                }
            }
        }
    }
}
