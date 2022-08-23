using DM.Shared.Core.Exceptions;

namespace DM.Module.Users.Exceptions
{
    internal class UserDeletedException : DmException
    {
        public string Login { get; }

        public UserDeletedException(string login) : base($"User with Login {login} is deleted.")
        {
            Login = login;
        }
    }
}
