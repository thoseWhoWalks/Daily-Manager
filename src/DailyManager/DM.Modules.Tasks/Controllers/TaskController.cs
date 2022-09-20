using DM.Modules.Tasks.Application.Commands.Tasks;
using DM.Modules.Tasks.Application.Queries.Tasks;
using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Commands;
using DM.Shared.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DM.Modules.Tasks.Controllers
{
    [Authorize, Route("api/tasks")]
    internal class TaskController : Controller
    {
        #region Dependencies

        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        #endregion

        public TaskController(
            IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher
            )
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        #region Queries

        [HttpGet, Route("{id:guid}")]
        public async Task<TaskModel?> GetAsync([FromRoute] GetTask query)
            => await _queryDispatcher.QueryAsync(query);

        [HttpGet, Route("mine/unlisted")]
        public async Task<IEnumerable<TaskModel>?> GetMineUnlistedAsync()
            => await _queryDispatcher.QueryAsync(new GetMineUnlistedTasks());

        [HttpGet, Route("mine/overdue")]
        public async Task<IEnumerable<TaskModel>?> GetMineOverdueAsync()
            => await _queryDispatcher.QueryAsync(new GetMineOverdueTasks());

        #endregion

        #region Commands

        [HttpPatch, Route("{id:guid}/edit/name")]
        public async Task RenameAsync([FromBody] RenameTask command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPatch, Route("{id:guid}/edit/description")]
        public async Task ChangeDescriptionAsync([FromBody] ChangeTaskDescription command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPatch, Route("{id:guid}/edit/execution-date")]
        public async Task ChangeExecutionDateAsync([FromBody] ChangeTaskExecutionDate command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPatch, Route("{id:guid}/set/execution-date")]
        public async Task SetExecutionDateAsync([FromBody] SetTaskExecutionDate command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPatch, Route("{id:guid}/execute")]
        public async Task ExecuteAsync([FromRoute] ExecuteTask command)
            => await _commandDispatcher.SendAsync(command);

        [HttpDelete, Route("{id:guid}/delete")]
        public async Task DeleteAsync([FromRoute] DeleteTask command)
            => await _commandDispatcher.SendAsync(command);

        [HttpPost, Route("{id:guid}/restore")]
        public async Task RestoreAsync([FromRoute] RestoreTask command)
            => await _commandDispatcher.SendAsync(command);

        #endregion
    }
}
