using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class CreateTaskOutOfListContextException : DmException
    {
        public CreateTaskOutOfListContextException() : base("Task can't be created out of Task List context.")
        {
        }
    }
}
