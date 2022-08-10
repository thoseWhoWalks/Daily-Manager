using DM.Modules.Tasks.Application.Queries.TaskLists;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Shared.Models.TaskLists;
using DM.Shared.Application.Queries;
using Mapster;

namespace DM.Modules.Tasks.Application.Queries.Handlers.TaskLists
{
    internal class GetTaskListHandler : IQueryHandler<GetTaskList, TaskListModel>
    {
        #region Dependencies

        private readonly ITaskListRepository _taskListRepository;

        #endregion

        public GetTaskListHandler(ITaskListRepository taskRepository)
        {
            _taskListRepository = taskRepository;
        }

        public TaskListModel? Handle(GetTaskList query)
        {
            var taskList = _taskListRepository.First(new ByIdSpecification<TaskList>(query.Id));

            return taskList?.Adapt<TaskListModel>();
        }

        public async Task<TaskListModel?> HandleAsync(GetTaskList query)
        {
            var taskList = await _taskListRepository
                .FirstAsync(new ByIdSpecification<TaskList>(query.Id));

            return taskList?.Adapt<TaskListModel>();
        }
    }
}
