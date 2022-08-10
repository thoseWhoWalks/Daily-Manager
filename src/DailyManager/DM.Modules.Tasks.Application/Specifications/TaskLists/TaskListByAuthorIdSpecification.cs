using DM.Modules.Tasks.Core.Aggregates;
using EntityFrameworkCore.CommonTools;

namespace DM.Modules.Tasks.Application.Specifications.TaskLists
{
    internal class TaskListByAuthorIdSpecification : Specification<TaskList>
    {
        public TaskListByAuthorIdSpecification(Guid authorId) 
            : base(tl => tl.AuthorId == authorId) { }
    }
}
