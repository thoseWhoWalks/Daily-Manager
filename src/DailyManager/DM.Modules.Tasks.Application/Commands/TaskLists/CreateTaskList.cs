using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    internal record CreateTaskList(string title, string? description) : ICommand;
}
