using DM.Shared.OutBox.Entities;
using Microsoft.EntityFrameworkCore;

namespace DM.Shared.OutBox.Context
{
    public abstract class OutBoxDbContext<TContext> : DbContext where TContext : DbContext
    {
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; } = null!;

        public OutBoxDbContext(DbContextOptions<TContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutBoxDbContext<>).Assembly);
    }
}
