namespace DM.Shared.Core.Aggregates
{
    public interface IDeletableAggreagateRoot
    {
        public bool IsDeleted { get; }
        public DateTime? DeletedAt { get;}

        public void Delete();
    }
}
