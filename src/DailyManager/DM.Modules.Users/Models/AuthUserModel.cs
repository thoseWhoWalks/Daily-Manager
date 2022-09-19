namespace DM.Module.Users.Models
{
    internal class AuthUserModel
    {
        public UserModel User { get; } = null!;
        public string Token { get; } = null!;
    }
}
