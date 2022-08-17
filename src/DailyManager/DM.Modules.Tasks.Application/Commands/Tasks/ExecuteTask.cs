using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    public record ExecuteTask(Guid id) : ICommand;
}
