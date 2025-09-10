using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProCeur.API.Database.EntityModels.Admin;

namespace ProCeur.API.Repositories.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole
                {
                    Id = 1,
                    Name = "Superadmin",
                    IsDefault = true,
                    CreatedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    CreatedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                    LastModifiedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    LastModifiedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                },
                new UserRole
                {
                    Id = 2,
                    Name = "User",
                    IsDefault = true,
                    CreatedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    CreatedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                    LastModifiedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    LastModifiedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                }
            );
        }
    }
}
