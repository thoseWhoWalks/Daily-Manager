using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    internal record ExecuteTask(Guid id) : ICommand;
}
