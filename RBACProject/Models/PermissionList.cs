using System.Collections.Generic;

namespace RBACProject.Models
{
    public static class PermissionList
    {
        public static List<Permission> GetAll() => new List<Permission>
        {
            new Permission
            {
                Id = "ViewRoles",
                Name = "View Roles",
                Description = "View roles"
            },
            new Permission
            {
                Id = "CreateRoles",
                Name = "Create Roles",
                Description = "Create roles"
            },
            new Permission
            {
                Id = "EditRoles",
                Name = "Edit Roles",
                Description = "Edit roles"
            },
            new Permission
            {
                Id = "DeleteRoles",
                Name = "Delete Roles",
                Description = "Delete roles"
            }
        };

        public const string ViewRoles = "ViewRoles";

        public const string CreateRoles = "CreateRoles";

        public const string EditRoles = "EditRoles";

        public const string DeleteRoles = "DeleteRoles";
    }
}
