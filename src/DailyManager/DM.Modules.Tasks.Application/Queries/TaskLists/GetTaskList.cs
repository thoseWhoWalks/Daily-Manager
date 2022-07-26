using DM.Modules.Tasks.Shared.Models.TaskLists;
using DM.Shared.Application.Queries;

namespace DM.Modules.Tasks.Application.Queries.TaskLists
{
    public class GetTaskList : IQuery<TaskListModel>
    {
        public Guid Id { get; set; }
    }
}
