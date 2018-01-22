using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RBACProject.Data;
using RBACProject.Models;
using System.Linq;

namespace RBACProject
{
    public class ApplicationInitializer
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ApplicationInitializer(IApplicationBuilder app)
        {
            _serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
        }

        private void InitializePermissions()
        {
            var systemPermissions = PermissionList.GetAll();

            using (var scopeScope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scopeScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                systemPermissions.ForEach(systemPermission =>
                {
                    var dbPermission = dbContext.Permissions.FirstOrDefault(dp => systemPermission.Id.Equals(dp.Id));

                    if (dbPermission == null)
                    {
                        dbContext.Permissions.Add(systemPermission);
                    }
                    else
                    {
                        dbPermission.Name = systemPermission.Name;
                        dbPermission.Description = systemPermission.Description;

                        dbContext.Update(dbPermission);
                    }
                });

                dbContext.Permissions.ToList().ForEach(dbPermission =>
                {
                    if(!systemPermissions.Any(systemPermission => systemPermission.Id.Equals(dbPermission.Id)))
                    {
                        dbContext.Permissions.Remove(dbPermission);
                    }
                });
                
                dbContext.SaveChanges();
            }
        }

        public void Run()
        {
            InitializePermissions();
        }
    }
}
