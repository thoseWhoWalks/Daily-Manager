using DM.Modules.Tasks.Application.Queries.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Application.Specifications.Tasks;
using DM.Modules.Tasks.Core.Const;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;
using Mapster;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Queries.Handlers.Tasks
{
    internal class GetOverdueTasksHandler
        : IQueryHandler<GetOverdueTasks, IEnumerable<TaskModel>>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public GetOverdueTasksHandler(ITaskRepository taskRepository)
            => _taskRepository = taskRepository;

        public IEnumerable<TaskModel>? Handle(GetOverdueTasks query)
        {
            var task = _taskRepository.First(new TaskByAuthorIdSpecification(query.AuthorId)
                && new ActiveSpecification<Task>() && new TaskByStateSpecification(TaskStates.Overdue));

            return task?.Adapt<IEnumerable<TaskModel>>();
        }

        public async Task<IEnumerable<TaskModel>?> HandleAsync(GetOverdueTasks query)
        {
            var task = await _taskRepository.FirstAsync(new TaskByAuthorIdSpecification(query.AuthorId)
                && new ActiveSpecification<Task>() && new TaskByStateSpecification(TaskStates.Overdue));

            return task?.Adapt<IEnumerable<TaskModel>>();
        }
    }
}
