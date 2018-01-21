using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBACProject.Models;

namespace RBACProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.RolePermissions).WithOne(e => e.Permission).HasForeignKey(e => e.PermissionId);
                entity.HasMany(e => e.UserPermissions).WithOne(e => e.Permission).HasForeignKey(e => e.PermissionId);
            });
            
            builder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId });

                entity.HasOne(e => e.Role).WithMany(e => e.RolePermissions).HasForeignKey(e => e.RoleId);
                entity.HasOne(e => e.Permission).WithMany(e => e.RolePermissions).HasForeignKey(e => e.PermissionId);
            });

            builder.Entity<UserPermission>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId });

                entity.HasOne(e => e.User).WithMany(e => e.UserPermissions).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Permission).WithMany(e => e.UserPermissions).HasForeignKey(e => e.PermissionId);
            });
        }
    }
}
