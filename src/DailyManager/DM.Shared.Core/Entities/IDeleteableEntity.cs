namespace DM.Shared.Core.Entities
{
    public interface IDeleteableEntity
    {
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
