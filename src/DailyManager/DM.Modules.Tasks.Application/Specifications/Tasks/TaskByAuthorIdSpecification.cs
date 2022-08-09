using EntityFrameworkCore.CommonTools;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Specifications.Tasks
{
    internal class TaskByAuthorIdSpecification : Specification<Task>
    {
        public TaskByAuthorIdSpecification(Guid authorId)
            : base(tl => tl.AuthorId == authorId) { }
    }
}
