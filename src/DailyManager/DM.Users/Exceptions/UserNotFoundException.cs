using DM.Shared.Core.Exceptions;

namespace DM.Module.Users.Exceptions
{
    internal class UserNotFoundException : DmException
    {
        public UserNotFoundException() : base("User not found.")
        {

        }
    }
}
