using MediatR;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace ProCeur.API.Shared.Helpers
{
    public abstract class RestrictableRequest<T> : IRequest<T>, IRestrictable
    {

        public Guid JwtUserId { get; set; }
        [JsonIgnore]
        public virtual Claim[] Permissions => Array.Empty<Claim>();
        public virtual Guid? UserId => JwtUserId;
    }

    public interface IRestrictable
    {
        public Claim[] Permissions { get; }
        public Guid? UserId { get; }
    }
}
