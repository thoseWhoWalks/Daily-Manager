using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Infrastructure.Context;
using DM.Shared.Infrastructure.Repositories;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Infrastructure.Repositories
{
    internal class TaskRepository :
        CrudRepository<Task>,
        ITaskRepository
    {
        public TaskRepository(TaskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
