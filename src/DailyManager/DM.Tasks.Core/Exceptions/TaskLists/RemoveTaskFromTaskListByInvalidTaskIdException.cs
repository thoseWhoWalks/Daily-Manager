using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.TaskLists
{
    internal class RemoveTaskFromTaskListByInvalidIdException : DmException
    {
        public RemoveTaskFromTaskListByInvalidIdException() 
            : base("Task can't be removed from TaskList due invalid Task id.")
        {
        }
    }
}
