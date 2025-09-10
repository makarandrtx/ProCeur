using ProCeur.API.Shared.Interface.EntityInterface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProCeur.API.Database.EntityModels.Admin
{
    [Table("Departments", Schema = "Admin")]
    public class Department : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }
        public bool IsDefault { get; set; }
    }
}
