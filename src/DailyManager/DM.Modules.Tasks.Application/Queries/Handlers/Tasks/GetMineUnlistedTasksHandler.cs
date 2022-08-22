using DM.Modules.Tasks.Application.Queries.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Application.Specifications.Tasks;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;
using DM.Shared.Infrastructure.Authentication;
using Mapster;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Queries.Handlers.Tasks
{
    internal class GetMineUnlistedTasksHandler
        : IQueryHandler<GetMineUnlistedTasks, IEnumerable<TaskModel>>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;
        private readonly IUserContext _userContext;

        #endregion

        public GetMineUnlistedTasksHandler(
            ITaskRepository taskRepository,
            IUserContext userContext
            )
        {
            _taskRepository = taskRepository;
            _userContext = userContext;
        }

        public IEnumerable<TaskModel>? Handle(GetMineUnlistedTasks query)
        {
            var task = _taskRepository.First(new TaskByAuthorIdSpecification(_userContext.UserId)
                && new TaskByTaskListIdSpecification(null) && new ActiveSpecification<Task>());

            return task?.Adapt<IEnumerable<TaskModel>>();
        }

        public async Task<IEnumerable<TaskModel>?> HandleAsync(GetMineUnlistedTasks query)
        {
            var task = await _taskRepository.FirstAsync(new TaskByAuthorIdSpecification(_userContext.UserId) 
                && new TaskByTaskListIdSpecification(null) && new ActiveSpecification<Task>());

            return task?.Adapt<IEnumerable<TaskModel>>();
        }
    }
}
