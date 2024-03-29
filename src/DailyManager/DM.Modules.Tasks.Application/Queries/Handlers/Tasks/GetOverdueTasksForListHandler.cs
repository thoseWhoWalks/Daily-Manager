﻿using DM.Modules.Tasks.Application.Queries.Tasks;
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
    internal class GetOverdueTasksForListHandler
        : IQueryHandler<GetOverdueTasksForList, IEnumerable<TaskModel>>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public GetOverdueTasksForListHandler(ITaskRepository taskRepository)
            => _taskRepository = taskRepository;

        public IEnumerable<TaskModel>? Handle(GetOverdueTasksForList query)
        {
            var task = _taskRepository.First(new TaskByTaskListIdSpecification(query.ListId)
                && new ActiveSpecification<Task>() && new TaskByStateSpecification(TaskStates.Overdue));

            return task?.Adapt<IEnumerable<TaskModel>>();
        }

        public async Task<IEnumerable<TaskModel>?> HandleAsync(GetOverdueTasksForList query)
        {
            var task = await _taskRepository.FirstAsync(new TaskByTaskListIdSpecification(query.ListId)
                && new ActiveSpecification<Task>() && new TaskByStateSpecification(TaskStates.Overdue));

            return task?.Adapt<IEnumerable<TaskModel>>();
        }
    }
}
