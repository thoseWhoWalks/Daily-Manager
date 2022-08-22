using DM.Modules.Tasks.Shared.Models.TaskLists;
using DM.Shared.Application.Queries;

namespace DM.Modules.Tasks.Application.Queries.TaskLists
{
    public class GetMineDeletedTaskLists : IQuery<IEnumerable<TaskListListItemModel>> {}
}
