using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Application.Exceptions.Tasks
{
    internal class TaskNotFoundException : DmException
    {
        public TaskNotFoundException() : base("Task with given Id not found.")
        {
        }
    }
}
