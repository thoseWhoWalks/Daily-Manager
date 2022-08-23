using DM.Shared.Core.Exceptions;

namespace DM.Module.Users.Exceptions
{
    internal class LoginUsedExeption : DmException
    {
        public string Login { get; }

        public LoginUsedExeption(string login) : base($"Login {login} is used already.")
        {
            Login = login;
        }
    }
}
