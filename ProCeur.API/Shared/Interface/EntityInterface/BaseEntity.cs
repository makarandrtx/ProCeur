namespace ProCeur.API.Shared.Interface.EntityInterface
{
    public interface IBaseEntity
    {
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public abstract class BaseEntity : IBaseEntity
    {
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
