using DM.Module.Users.Entities;
using DM.Shared.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DM.Module.Users.Context
{
    internal class UserDbContext : DmDbContext<UserDbContext>
    {
        #region Constants

        private const string Schema = "users";

        #endregion

        public DbSet<User> Users { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(Schema, options)
        {
            Database.EnsureCreated();
        }
    }
}
