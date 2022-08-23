using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.TaskLists
{
    internal class AddNullTaskToTaskListException : DmException
    {
        public AddNullTaskToTaskListException() : base("Null as Task can't be added to TaskList.")
        {
        }
    }
}
