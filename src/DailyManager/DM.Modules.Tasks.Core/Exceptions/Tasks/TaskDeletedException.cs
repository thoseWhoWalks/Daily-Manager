using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class TaskDeletedException : DmException
    {
        public TaskDeletedException(string title) : base($"Task {title} deleted.")
        {
        }
    }
}
