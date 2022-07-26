using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;

namespace DM.Modules.Tasks.Application.Queries.Tasks
{
    public class GetOverdueTasks : IQuery<IEnumerable<TaskListItemModel>>
    {
        public Guid AuthorId { get; set; }
    }
}
