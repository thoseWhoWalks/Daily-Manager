using DM.Shared.OutBox.Entities;
using Microsoft.EntityFrameworkCore;

namespace DM.Shared.OutBox.Context
{
    public abstract class OutBoxDbContext : DbContext
    {
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; } = null!;

        protected OutBoxDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutBoxDbContext).Assembly);
    }
}
