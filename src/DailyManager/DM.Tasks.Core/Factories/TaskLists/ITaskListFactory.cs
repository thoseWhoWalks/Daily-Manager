using DM.Modules.Tasks.Core.Aggregates;

namespace DM.Modules.Tasks.Core.Factories.TaskLists
{
    public interface ITaskListFactory
    {
        TaskList Create(Guid authorId, string title, string? description);
    }
}
