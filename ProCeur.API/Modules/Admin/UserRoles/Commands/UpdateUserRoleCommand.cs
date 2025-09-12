using MediatR;
using ProCeur.API.Database.EntityModels.Admin;
using ProCeur.API.Modules.Admin.UserRoles.ViewModels;
using ProCeur.API.Shared.Interface;
using ProCeur.API.Shared.Wrappers;

namespace ProCeur.API.Modules.Admin.UserRoles.Commands
{
    public class UpdateUserRoleCommand : UserRoleCommand { }
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, Response<int>>
    {
        private readonly IGenericRepository<UserRole> _userRoleRepo;
        public UpdateUserRoleCommandHandler(IGenericRepository<UserRole> userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }
        public async Task<Response<int>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var tempGuid = Guid.Parse("1e19f33e-20d7-4389-89e0-196e4333ac15");
            var userRoleToUpdate = await _userRoleRepo.GetByIdWithTracking(request.Id);
            if(userRoleToUpdate == null)
            {
                throw new KeyNotFoundException($"UserRole with Id {request.Id} not found.");
            }

            if(userRoleToUpdate.IsDefault)
            {
                throw new InvalidOperationException("Default UserRoles cannot be modified.");
            }

            userRoleToUpdate.Name = request.Name.Trim();
            
            await _userRoleRepo.SaveChangesAsync(tempGuid, cancellationToken);

            return new Response<int>(userRoleToUpdate.Id);
        }
    }
}
