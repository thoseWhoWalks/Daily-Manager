using DM.Modules.Tasks.Core.Const;
using EntityFrameworkCore.CommonTools;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Specifications.Tasks
{
    internal class TaskByStateSpecification : Specification<Task>
    {
        public TaskByStateSpecification(TaskStates state) 
            : base(t => t.State == state) {}
    }
}
