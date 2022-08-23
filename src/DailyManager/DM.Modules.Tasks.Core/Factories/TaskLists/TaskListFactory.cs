using DM.Modules.Tasks.Core.Aggregates;

namespace DM.Modules.Tasks.Core.Factories.TaskLists
{
    public class TaskListFactory : ITaskListFactory
    {
        public TaskList Create(Guid authorId, string title, string? description)
            => new(authorId, title, description);
    }
}
