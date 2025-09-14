using Microsoft.EntityFrameworkCore;
using ProCeur.API.Database.EntityModels.Admin;
using ProCeur.API.Repositories.Configurations;
using ProCeur.API.Shared.Interface.EntityInterface;

namespace ProCeur.API.Shared
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        //add DbSets for Entity Models here
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        //add users dbset next

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //left blank for now, as no seed-data required.
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }

        /// <summary>
        /// override implementation of SaveChangesAsync to set CreatedBy and ModifiedBy fields automatically.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            SetCreatedBy(userId);
            SetModifiedBy(userId);
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetCreatedBy(Guid userId)
        {
            // var userId = _authenticatedUserService.UserId;
            var entries = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                entry.Entity.IsActive = true;
                entry.Entity.CreatedDate = DateTime.UtcNow;
                entry.Entity.CreatedById = userId;
            }
        }

        private void SetModifiedBy(Guid userId)
        {
            // var userId = _authenticatedUserService.UserId;
            var entries = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;
                entry.Entity.LastModifiedById = userId;
            }
        }
    }
}
