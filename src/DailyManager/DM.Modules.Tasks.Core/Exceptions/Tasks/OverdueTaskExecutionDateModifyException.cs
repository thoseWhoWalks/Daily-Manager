using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class OverdueTaskExecutionDateModifyException : DmException
    {
        public OverdueTaskExecutionDateModifyException() 
            : base("Overdue Task execution date can't be modified.")
        {
        }
    }
}
