using DM.Modules.Tasks.Application.Queries.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Application.Specifications.Tasks;
using DM.Modules.Tasks.Core.Const;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;
using DM.Shared.Infrastructure.Authentication;
using Mapster;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Queries.Handlers.Tasks
{
    internal class GetMineOverdueTasksHandler
        : IQueryHandler<GetMineOverdueTasks, IEnumerable<TaskModel>>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;
        private readonly IUserContext _userContext;

        #endregion

        public GetMineOverdueTasksHandler(
            ITaskRepository taskRepository,
            IUserContext userContext
            )
        {
            _taskRepository = taskRepository;
            _userContext = userContext;
        }

        public IEnumerable<TaskModel>? Handle(GetMineOverdueTasks query)
        {
            var task = _taskRepository.First(new TaskByAuthorIdSpecification(_userContext.UserId)
                && new ActiveSpecification<Task>() && new TaskByStateSpecification(TaskStates.Overdue));

            return task?.Adapt<IEnumerable<TaskModel>>();
        }

        public async Task<IEnumerable<TaskModel>?> HandleAsync(GetMineOverdueTasks query)
        {
            var task = await _taskRepository.FirstAsync(new TaskByAuthorIdSpecification(_userContext.UserId)
                && new ActiveSpecification<Task>() && new TaskByStateSpecification(TaskStates.Overdue));

            return task?.Adapt<IEnumerable<TaskModel>>();
        }
    }
}
