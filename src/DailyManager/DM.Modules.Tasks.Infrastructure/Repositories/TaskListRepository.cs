using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Infrastructure.Context;
using DM.Shared.Infrastructure.Repositories;

namespace DM.Modules.Tasks.Infrastructure.Repositories
{
    internal class TaskListRepository :
        CrudRepository<TaskList>,
        ITaskListRepository
    {
        public TaskListRepository(TaskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
