using DM.Modules.Tasks.Application.Commands.TaskLists;
using DM.Modules.Tasks.Application.Queries.TaskLists;
using DM.Modules.Tasks.Application.Queries.Tasks;
using DM.Modules.Tasks.Shared.Models.TaskLists;
using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Commands;
using DM.Shared.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DM.Modules.Tasks.Controllers
{
    [Route("api/task-lists")]
    internal class TaskListController : Controller
    {
        #region Dependencies

        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        #endregion

        public TaskListController(
            IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher
            )
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        #region Queries

        [HttpGet, Route("{id:guid}")]
        public async Task<TaskListModel?> GetAsync([FromRoute] GetTaskList query)
            => await _queryDispatcher.QueryAsync(query);

        [HttpGet, Route("mine")]
        public async Task<IEnumerable<TaskListListItemModel>?> GetMineAsync()
            => await _queryDispatcher.QueryAsync(new GetMineTaskLists());

        [HttpGet, Route("mine/deleted")]
        public async Task<IEnumerable<TaskListListItemModel>?> GetMineDeletedAsync()
            => await _queryDispatcher.QueryAsync(new GetMineDeletedTaskLists());

        [HttpGet, Route("{id:guid}/tasks")]
        public async Task<IEnumerable<TaskListItemModel>?> GetTasksAsync([FromRoute] GetTasksForList query)
            => await _queryDispatcher.QueryAsync(query);

        [HttpGet, Route("{id:guid}/tasks/overdue")]
        public async Task<IEnumerable<TaskModel>?> GetOverdueTasksAsync([FromRoute] GetOverdueTasksForList query)
            => await _queryDispatcher.QueryAsync(query);

        [HttpGet, Route("{id:guid}/tasks/deleted")]
        public async Task<IEnumerable<TaskListItemModel>?> GetDeletedTasksAsync([FromRoute] GetDeletedTasksForList query)
            => await _queryDispatcher.QueryAsync(query);

        #endregion

        #region Commands

        [HttpPost]
        public async Task CreateAsync([FromBody] CreateTaskList command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPatch, Route("{id:guid}/edit/name")]
        public async Task RenameAsync([FromBody] RenameTaskList command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPatch, Route("{id:guid}/edit/description")]
        public async Task ChangeDescriptionAsync([FromBody] ChangeTaskListDescription command)
            => await _commandDispatcher.SendAsync(command);

        [HttpDelete, Route("{id:guid}/delete")]
        public async Task DeleteAsync([FromRoute] DeleteTaskList command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPost, Route("{id:guid}/tasks")]
        public async Task AddTaskAsync([FromBody] AddTaskToTaskList command)
            => await _commandDispatcher.SendAsync(command);

        [HttpDelete, Route("{id:guid}/tasks/{taskId:guid}")]
        public async Task RemoveTaskAsync([FromRoute] RemoveTaskFromTaskList command)
            => await _commandDispatcher.SendAsync(command);

        #endregion
    }
}
