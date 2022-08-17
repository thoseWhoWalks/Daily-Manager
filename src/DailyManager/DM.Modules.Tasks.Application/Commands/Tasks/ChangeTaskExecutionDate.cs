using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    public record ChangeTaskExecutionDate(Guid id, DateTime? executionDate) : ICommand;
}
