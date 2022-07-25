using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    internal record RenameTaskList(Guid id, string title) : ICommand;
}
