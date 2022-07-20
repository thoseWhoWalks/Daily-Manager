using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.TaskLists
{
    internal class DeleteTaskListWithTasksException : DmException
    {
        public DeleteTaskListWithTasksException() 
            : base("Task List with any not deleted Tasks can't be deleted.")
        {
        }
    }
}
