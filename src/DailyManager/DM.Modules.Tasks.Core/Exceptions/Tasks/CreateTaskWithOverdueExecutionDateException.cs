using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class CreateTaskWithOverdueExecutionDateException : DmException
    {
        public CreateTaskWithOverdueExecutionDateException()  
            : base("Task can't be created with overdue execution date.")
        {
        }
    }
}
