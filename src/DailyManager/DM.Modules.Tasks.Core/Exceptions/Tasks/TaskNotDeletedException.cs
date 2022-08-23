using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Tasks
{
    internal class NotDeletedTaskRestoreException : DmException
    {
        public NotDeletedTaskRestoreException() : base("Not deleted Task can't be restored.")
        {
        }
    }
}
