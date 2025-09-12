using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProCeur.API.Modules.Admin.UserRoles.Commands;
using ProCeur.API.Modules.Admin.UserRoles.Queries;

namespace ProCeur.API.Controllers.Account
{
    public class UserRoleController : BaseController
    {
        public UserRoleController(IMediator mediator) : base(mediator) { }

        [HttpGet("GetAllUserRoles")]
        public async Task<ObjectResult> GetAllUserRoles(GetAllUserRolesQuery getAllUserRoles)
        {
            return await Ok(getAllUserRoles);
        }

        [HttpPost("CreateUserRole")]
        public async Task<ObjectResult> CreateUserRole(CreateUserRoleCommand createUserRole)
        {
            return await Ok(createUserRole);
        }

        [HttpPost("UpdateUserRole")]
        public async Task<ObjectResult> UpdateUserRole(UpdateUserRoleCommand updateUserRole)
        {
            return await Ok(updateUserRole);
        }
    }
}
