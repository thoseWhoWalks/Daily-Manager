namespace DM.Module.Users.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Login { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
