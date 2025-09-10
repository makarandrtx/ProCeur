using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProCeur.API.Database.EntityModels.Admin;

namespace ProCeur.API.Repositories.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = 1,
                    DepartmentName = "Cassiolli",
                    IsDefault = true,
                    IsActive = true,
                    CreatedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    CreatedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                    LastModifiedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    LastModifiedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                },
                new Department
                {
                    Id = 2,
                    DepartmentName = "Coppershop",
                    IsDefault = true,
                    IsActive = true,
                    CreatedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    CreatedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                    LastModifiedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    LastModifiedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                },
                new Department
                {
                    Id = 3,
                    DepartmentName = "FAT",
                    IsDefault = true,
                    IsActive = true,
                    CreatedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    CreatedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                    LastModifiedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    LastModifiedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                },
                new Department
                {
                    Id = 4,
                    DepartmentName = "Stores",
                    IsDefault = true,
                    IsActive = true,
                    CreatedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    CreatedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                    LastModifiedById = Guid.Parse("b352141f-3603-44d5-b136-a39c9f9ee2e0"),
                    LastModifiedDate = DateTime.Parse("2025-07-01 19:26:13.1455952"),
                }
            );
        }
    }
}
