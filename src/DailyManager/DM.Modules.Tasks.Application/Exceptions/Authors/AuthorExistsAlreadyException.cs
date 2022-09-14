using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Application.Exceptions.Authors
{
    internal class AuthorExistsAlreadyException : DmException
    {
        public AuthorExistsAlreadyException() : base("Author with given Id exists already.")
        {
        }
    }
}
