namespace RBACProject.Models
{
    public class UserPermission
    {
        public string UserId { get; set; }
        public string PermissionId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
