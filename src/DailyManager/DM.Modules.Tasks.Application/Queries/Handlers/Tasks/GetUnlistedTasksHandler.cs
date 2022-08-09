using DM.Modules.Tasks.Application.Queries.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Application.Specifications.Tasks;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;
using Mapster;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Queries.Handlers.Tasks
{
    internal class GetUnlistedTasksHandler
        : IQueryHandler<GetUnlistedTasks, IEnumerable<TaskModel>>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public GetUnlistedTasksHandler(ITaskRepository taskRepository)
            => _taskRepository = taskRepository;

        public IEnumerable<TaskModel>? Handle(GetUnlistedTasks query)
        {
            var task = _taskRepository.First(new TaskByAuthorIdSpecification(query.AuthorId)
                && new TaskByTaskListIdSpecification(null) && new ActiveSpecification<Task>());

            return task?.Adapt<IEnumerable<TaskModel>>();
        }

        public async Task<IEnumerable<TaskModel>?> HandleAsync(GetUnlistedTasks query)
        {
            var task = await _taskRepository.FirstAsync(new TaskByAuthorIdSpecification(query.AuthorId) 
                && new TaskByTaskListIdSpecification(null) && new ActiveSpecification<Task>());

            return task?.Adapt<IEnumerable<TaskModel>>();
        }
    }
}
