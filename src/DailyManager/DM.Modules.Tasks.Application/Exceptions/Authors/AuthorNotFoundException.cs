using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Application.Exceptions.Authors
{
    internal class AuthorNotFoundException : DmException
    {
        public AuthorNotFoundException() : base("Author with given Id not found.")
        {
        }
    }
}
