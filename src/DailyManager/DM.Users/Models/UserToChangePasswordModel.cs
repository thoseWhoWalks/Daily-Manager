namespace DM.Module.Users.Models
{
    public class UserToChangePasswordModel
    {
        public Guid Id { get; set; }

        public string Password { get; set; } = null!;
    }
}
