
namespace DM.Modules.Tasks.Core.Factories.Tasks
{
    public interface ITaskFactory
    {
        Aggregates.Task Create(Guid authorId, string title, string? description,
            DateTime? executeAt);
        Aggregates.Task CreateForList(Guid authorId, Guid listId, string title,
            string? description, DateTime? executeAt);
    }
}
