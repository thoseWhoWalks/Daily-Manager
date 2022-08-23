using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Authors
{
    internal class AuthorDeletedException : DmException
    {
        public AuthorDeletedException(string login) : base($"Author with {login} login deleted.")
        {
        }
    }
}
