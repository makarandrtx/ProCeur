using System.ComponentModel.DataAnnotations.Schema;

namespace ProCeur.API.Database.EntityModels.Admin
{
    public class User 
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        [ForeignKey("UserRoleId")]
        public virtual UserRole Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiryTime { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
