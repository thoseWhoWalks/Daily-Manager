using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    public record RemoveTaskFromTaskList(Guid id, Guid taskId) : ICommand;
}
