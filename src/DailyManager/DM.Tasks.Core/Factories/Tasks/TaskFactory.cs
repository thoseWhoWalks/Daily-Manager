namespace DM.Modules.Tasks.Core.Factories.Tasks
{
    public class TaskFactory : ITaskFactory
    {
        public Aggregates.Task Create(Guid authorId, string title, string? description,
            DateTime? executeAt)
            => new(authorId, title, description, executeAt);

        public Aggregates.Task CreateForList(Guid authorId, Guid listId, string title, 
            string? description, DateTime? executeAt)
            => new(authorId, listId, title, description, executeAt);
    }
}
