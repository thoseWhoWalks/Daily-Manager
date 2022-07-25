using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    internal record DeleteTaskList(Guid id) : ICommand;
}
