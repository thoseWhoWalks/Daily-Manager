using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Authors
{
    internal class ChangeAuthorLoginToEmptyException : DmException
    {
        public ChangeAuthorLoginToEmptyException() : base("Author title can't be changed to empty.")
        {
        }
    }
}
