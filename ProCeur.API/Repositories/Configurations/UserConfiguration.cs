using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProCeur.API.Database.EntityModels.Admin;

namespace ProCeur.API.Repositories.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("28e1cd24-4cbd-4628-bc3b-2af0719efca3"),
                    Firstname = "Superadmin",
                    Lastname = "Superadmin",
                    Email = "superadmin@email.com",
                    Password = "ZdI02Zov/Puh7ZZyBDPYkg==",
                    UserRoleId = 1,
                    IsAdmin = true,
                }
            );
        }
    }
}
