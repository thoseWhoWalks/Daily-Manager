using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    public record ChangeTaskDescription(Guid id, string? description) : ICommand;
}
