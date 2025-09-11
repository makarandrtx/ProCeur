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
        public async Task<ObjectResult> GetAllUserRoles()
        {
            return await Ok<GetAllUserRolesQuery>(null);
        }

        [HttpPost("CreateUserRole")]
        public async Task<ObjectResult> CreateUserRole()
        {
            return await Ok<CreateUserRoleCommand>(null);
        }
    }
}
