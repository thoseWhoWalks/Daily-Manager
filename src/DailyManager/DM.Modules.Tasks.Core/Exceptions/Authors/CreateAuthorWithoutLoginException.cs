using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Authors
{
    internal class CreateAuthorWithoutLoginException : DmException
    {
        public CreateAuthorWithoutLoginException() : base("Author can't be created without login.")
        {
        }
    }
}
