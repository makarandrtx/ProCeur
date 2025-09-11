using ProCeur.API.Shared.Helpers;
using ProCeur.API.Shared.Wrappers;

namespace ProCeur.API.Modules.Admin.UserRoles.ViewModels
{
    public class UserRoleCommand : RestrictableRequest<Response<int>>
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
