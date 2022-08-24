using DM.Modules.Tasks.Core.Aggregates;
using DM.Shared.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Infrastructure.Context
{
    internal class TaskDbContext : DmDbContext<TaskDbContext>
    {
        #region Constants

        private const string Schema = "tasks";

        #endregion

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<TaskList> TaskLists { get; set; } = null!;

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(Schema, options)
        {
            Database.EnsureCreated();
        }
    }
}
