namespace DM.Module.Users.Models
{
    internal class UserToUpdateModel
    {
        public Guid Id { get; set; }

        public string Login { get; set; } = null!;
    }
}
