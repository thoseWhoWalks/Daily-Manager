using DM.Shared.OutBox.Entities;
using Microsoft.EntityFrameworkCore;

namespace DM.Shared.OutBox.Context
{
    public abstract class OutBoxDbContext : DbContext
    {
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; } = null!;

        public OutBoxDbContext(DbContextOptions<OutBoxDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
