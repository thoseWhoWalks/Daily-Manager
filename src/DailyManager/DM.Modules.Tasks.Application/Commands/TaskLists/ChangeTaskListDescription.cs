using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    public record ChangeTaskListDescription(Guid id, string description) : ICommand;
}
