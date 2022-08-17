using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    public record DeleteTask(Guid id) : ICommand;
}
