using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    internal record ChangeTaskDescription(Guid id, string? description) : ICommand;
}
