using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class CreateTaskWithoutAuthorException : DmException
    {
        public CreateTaskWithoutAuthorException() : base("Task can't be created without Author.")
        {
        }
    }
}
