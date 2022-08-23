using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class ExecutedTaskExecutionException : DmException
    {
        public ExecutedTaskExecutionException() : base("Executed Task can't be executed again.")
        {
        }
    }
}
