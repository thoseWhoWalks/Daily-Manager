using DM.Shared.Core.Entities;

namespace DM.Module.Users.Entities
{
    internal class User :
        IEntity,
        ICreateableEntity,
        IUpdateableEntity,
        IDeleteableEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Login { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
