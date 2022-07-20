using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class CreateTaskWithoutTitleException : DmException
    {
        public CreateTaskWithoutTitleException() : base("Task can't be created without title.")
        {
        }
    }
}
