using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    internal record ChangeTaskExecutionDate(Guid id, DateTime? executionDate) : ICommand;
}
