using System.Collections.Generic;

namespace RBACProject.Models
{
    public static class PermissionList
    {
        public static List<Permission> GetAll() => new List<Permission>
        {
            ViewRoles,
            CreateRoles,
            EditRoles,
            DeleteRoles
        };

        public static Permission ViewRoles = new Permission
        {
            Id = "ViewRoles",
            Name = "View Roles",
            Description = "View roles"
        };

        public static Permission CreateRoles = new Permission
        {
            Id = "CreateRoles",
            Name = "Create Roles",
            Description = "Create roles"
        };

        public static Permission EditRoles = new Permission
        {
            Id = "EditRoles",
            Name = "Edit Roles",
            Description = "Edit roles"
        };

        public static Permission DeleteRoles = new Permission
        {
            Id = "DeleteRoles",
            Name = "Delete Roles",
            Description = "Delete roles"
        };
    }
}
