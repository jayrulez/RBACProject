namespace RBACProject.Models
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public string PermissionId { get; set; }

        public virtual ApplicationRole Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
