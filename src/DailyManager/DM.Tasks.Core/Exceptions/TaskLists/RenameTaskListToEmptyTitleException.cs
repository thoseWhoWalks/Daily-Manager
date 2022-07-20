using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.TaskLists
{
    internal class RenameTaskListToEmptyTitleException : DmException
    {
        public RenameTaskListToEmptyTitleException() : base("Task List title can't be changed to empty.")
        {

        }
    }
}
