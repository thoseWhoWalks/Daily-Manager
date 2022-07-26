using DM.Modules.Tasks.Shared.Models.TaskLists;
using DM.Shared.Application.Queries;

namespace DM.Modules.Tasks.Application.Queries.TaskLists
{
    public class GetDeletedTaskLists : IQuery<IEnumerable<TaskListListItemModel>>
    {
        public Guid AuthorId { get; set; }
    }
}
