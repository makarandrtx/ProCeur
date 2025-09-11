using MediatR;
using ProCeur.API.Database.EntityModels.Admin;
using ProCeur.API.Modules.Admin.UserRoles.ViewModels;
using ProCeur.API.Shared.Interface;
using ProCeur.API.Shared.Wrappers;

namespace ProCeur.API.Modules.Admin.UserRoles.Commands
{
    public class CreateUserRoleCommand : UserRoleCommand { }
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Response<int>>
    {
        private readonly IGenericRepository<UserRole> _userRoleRepo;
        public async Task<Response<int>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRoleToAdd = await _userRoleRepo.AddAsync(new UserRole
            {
                Name = request.Name.Trim(),
                IsDefault = false,
                IsActive = true
            }, new Guid("1e19f33e-20d7-4389-89e0-196e4333ac15"));

            return new Response<int>(userRoleToAdd.Id);
        }
    }
}
