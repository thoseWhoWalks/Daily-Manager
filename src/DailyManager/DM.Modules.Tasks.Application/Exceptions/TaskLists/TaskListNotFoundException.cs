using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Application.Exceptions.TaskLists
{
    internal class TaskListNotFoundException : DmException
    {
        public TaskListNotFoundException() : base("Task List with given Id not found.")
        {
        }
    }
}
