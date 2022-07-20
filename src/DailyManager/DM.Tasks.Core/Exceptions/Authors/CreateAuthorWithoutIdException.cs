using DM.Shared.Core.Exceptions;

namespace DM.Modules.Tasks.Core.Exceptions.Authors
{
    internal class CreateAuthorWithoutIdException : DmException
    {
        public CreateAuthorWithoutIdException() : base("Author can't be created without id.")
        {
        }
    }
}
