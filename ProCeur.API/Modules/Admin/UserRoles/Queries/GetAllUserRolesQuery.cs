using MediatR;
using Microsoft.EntityFrameworkCore;
using ProCeur.API.Database.EntityModels.Admin;
using ProCeur.API.Shared.Helpers;
using ProCeur.API.Shared.Interface;
using ProCeur.API.Shared.Models;

namespace ProCeur.API.Modules.Admin.UserRoles.Queries
{
    public class GetAllUserRolesQuery : RestrictableRequest<IEnumerable<DropDownViewModel>> { }
    public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, IEnumerable<DropDownViewModel>>
    {
        private readonly IGenericRepository<UserRole> _userRoleRepo;
        public GetAllUserRolesQueryHandler(IGenericRepository<UserRole> userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }
        public async Task<IEnumerable<DropDownViewModel>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleRepo.GetAllWithoutTracking()
                .Where(w => w.Id != (int) Shared.Enums.UserRoles.Superadmin && w.IsDefault)
                .OrderBy(o => o.Name)
                .Select(x => new DropDownViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync(cancellationToken);
        }
    }
}
