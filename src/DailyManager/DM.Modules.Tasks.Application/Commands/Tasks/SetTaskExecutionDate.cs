using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    public record SetTaskExecutionDate(Guid id, DateTime executionDate) : ICommand;
}
