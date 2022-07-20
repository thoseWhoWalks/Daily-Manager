using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.TaskLists
{
    internal class CreateTaskListWithoutAuthorException : DmException
    {
        public CreateTaskListWithoutAuthorException() : base("Task List can't be created without Author.")
        {
        }
    }
}
