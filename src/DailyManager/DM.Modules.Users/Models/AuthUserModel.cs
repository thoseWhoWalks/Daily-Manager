namespace DM.Module.Users.Models
{
    public class AuthUserModel
    {
        public Guid Id { get; }

        public AuthUserModel(Guid id)
        {
            Id = id;
        }
    }
}
