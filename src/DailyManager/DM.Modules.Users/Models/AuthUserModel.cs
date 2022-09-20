namespace DM.Module.Users.Models
{
    internal class AuthUserModel
    {
        public UserModel User { get; } = null!;
        public string Token { get; } = null!;

        public AuthUserModel(UserModel user, string token)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }
    }
}
