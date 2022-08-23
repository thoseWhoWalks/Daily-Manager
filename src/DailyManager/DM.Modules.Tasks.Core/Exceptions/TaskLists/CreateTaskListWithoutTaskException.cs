using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.TaskLists
{
    internal class CreateTaskListWithPredefinedTasksWithoutAnyTaskException : DmException
    {
        public CreateTaskListWithPredefinedTasksWithoutAnyTaskException() 
            : base("TaskList with predefined Tasks construction can't be used without any Task.")
        {
        }
    }
}
