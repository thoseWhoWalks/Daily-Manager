using Microsoft.EntityFrameworkCore;

namespace DM.Shared.Infrastructure.Context
{
    public abstract class DmDbContext<TContext> : DbContext where TContext : DbContext
    {
        #region Private fields

        private readonly string _prefix;

        #endregion

        public DmDbContext(string prefix, DbContextOptions<TContext> options) : base(options)
        {
            _prefix = prefix;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_prefix);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
