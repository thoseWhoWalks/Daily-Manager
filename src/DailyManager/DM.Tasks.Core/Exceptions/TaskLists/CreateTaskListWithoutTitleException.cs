using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.TaskLists
{
    internal class CreateTaskListWithoutTitleException : DmException
    {
        public CreateTaskListWithoutTitleException() : base("Task List can't be created without title.")
        {
        }
    }
}
