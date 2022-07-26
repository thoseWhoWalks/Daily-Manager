using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;

namespace DM.Modules.Tasks.Application.Queries.Tasks
{
    public class GetUnlistedTasks : IQuery<IEnumerable<TaskModel>>
    {
        public Guid AuthorId { get; set; }
    }
}
