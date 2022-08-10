using DM.Modules.Tasks.Application.Queries.TaskLists;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Application.Specifications.TaskLists;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Shared.Models.TaskLists;
using DM.Shared.Application.Queries;
using DM.Shared.Infrastructure.Authentication;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DM.Modules.Tasks.Application.Queries.Handlers.TaskLists
{
    internal class GetDeletedTaskListsHandler 
        : IQueryHandler<GetDeletedTaskLists, IEnumerable<TaskListListItemModel>>
    {
        #region Dependencies

        private readonly ITaskListRepository _taskListRepository;
        private readonly IUserContext _userContext;

        #endregion

        public GetDeletedTaskListsHandler(
            ITaskListRepository taskRepository,
            IUserContext userContext
            )
        {
            _taskListRepository = taskRepository;
            _userContext = userContext;
        }

        public IEnumerable<TaskListListItemModel>? Handle(GetDeletedTaskLists query)
        {
            var taskLists = _taskListRepository
                .GetAll(new TaskListByAuthorIdSpecification(_userContext.UserId)
                    && !new ActiveSpecification<TaskList>())
                .ToList();

            return taskLists.Adapt<IEnumerable<TaskListListItemModel>>();
        }

        public async Task<IEnumerable<TaskListListItemModel>?> HandleAsync(GetDeletedTaskLists query)
        {
            var taskLists = await _taskListRepository
                .GetAll(new TaskListByAuthorIdSpecification(_userContext.UserId)
                    && !new ActiveSpecification<TaskList>())
                .ToListAsync();

            return taskLists.Adapt<IEnumerable<TaskListListItemModel>>();
        }
    }
}
