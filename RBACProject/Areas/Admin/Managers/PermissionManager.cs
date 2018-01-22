using RBACProject.Data;

namespace RBACProject.Areas.Admin.Managers
{
    public class PermissionManager
    {
        private readonly ApplicationDbContext _dbContext;

        public PermissionManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
