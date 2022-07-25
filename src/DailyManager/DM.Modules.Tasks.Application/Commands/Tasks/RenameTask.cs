using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Tasks
{
    internal record RenameTask(Guid id, string title) : ICommand;
}
