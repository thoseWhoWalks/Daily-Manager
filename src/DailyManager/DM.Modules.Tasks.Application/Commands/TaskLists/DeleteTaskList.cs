using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    public record DeleteTaskList(Guid id) : ICommand;
}
