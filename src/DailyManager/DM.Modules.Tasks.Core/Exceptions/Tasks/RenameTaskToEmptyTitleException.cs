using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class RenameTaskToEmptyTitleException : DmException
    {
        public RenameTaskToEmptyTitleException() : base("Task title can't be changed to empty.")
        {
        }
    }
}
