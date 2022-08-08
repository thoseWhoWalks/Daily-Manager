using EntityFrameworkCore.CommonTools;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Specifications.Tasks
{
    internal class TaskByTaskListIdSpecification : Specification<Task>
    {
        public TaskByTaskListIdSpecification(Guid? taskListId) 
            : base(t => t.ListId == taskListId) { }
    }
}
