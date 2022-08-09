using DM.Modules.Tasks.Application.Queries.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;
using Mapster;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Queries.Handlers.Tasks
{
    internal class GetTaskHandler : IQueryHandler<GetTask, TaskModel>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public GetTaskHandler(ITaskRepository taskRepository)
            => _taskRepository = taskRepository;

        public TaskModel? Handle(GetTask query)
        {
            var task = _taskRepository.First(new ByIdSpecification<Task>(query.id));

            return task?.Adapt<TaskModel>();
        }

        public async Task<TaskModel?> HandleAsync(GetTask query)
        {
            var taskList = await _taskRepository.FirstAsync(new ByIdSpecification<Task>(query.id));

            return taskList?.Adapt<TaskModel>();
        }
    }
}
