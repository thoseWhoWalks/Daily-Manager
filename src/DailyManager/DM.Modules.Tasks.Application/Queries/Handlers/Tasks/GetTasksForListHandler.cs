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
    internal class GetTasksForListHandler
        : IQueryHandler<GetTasksForList, IEnumerable<TaskListItemModel>>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public GetTasksForListHandler(ITaskRepository taskRepository)
            => _taskRepository = taskRepository;

        public IEnumerable<TaskListItemModel>? Handle(GetTasksForList query)
        {
            var task = _taskRepository.First(new TaskByTaskListIdSpecification(query.ListId)
                && new ActiveSpecification<Task>());

            return task?.Adapt<IEnumerable<TaskListItemModel>>();
        }

        public async Task<IEnumerable<TaskListItemModel>?> HandleAsync(GetTasksForList query)
        {
            var task = await _taskRepository.FirstAsync(new TaskByTaskListIdSpecification(query.ListId)
                && new ActiveSpecification<Task>());

            return task?.Adapt<IEnumerable<TaskListItemModel>>();
        }
    }
}
