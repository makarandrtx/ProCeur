using ProCeur.API.Shared.Interface.EntityInterface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProCeur.API.Database.EntityModels.Admin
{
    [Table("UserRoles", Schema = "Admin")]
    public class UserRole : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
