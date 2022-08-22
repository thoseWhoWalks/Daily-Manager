using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;

namespace DM.Modules.Tasks.Application.Queries.Tasks
{
    public class GetMineOverdueTasks : IQuery<IEnumerable<TaskModel>> { }
}
