using DM.Shared.OutBox.Context;
using Microsoft.EntityFrameworkCore;

namespace DM.Shared.Infrastructure.Context
{
    public abstract class DmDbContext : OutBoxDbContext
    {
        #region Private fields

        private readonly string _prefix;

        #endregion

        protected DmDbContext(string prefix, DbContextOptions options) : base(options)
        {
            _prefix = prefix;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(_prefix);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
