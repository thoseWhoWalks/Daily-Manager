using DM.Modules.Tasks.Application.Commands.Tasks;
using DM.Modules.Tasks.Application.Exceptions.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Commands.Handlers.Tasks
{
    internal class RestoreTaskHandler : ICommandHandler<RestoreTask>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public RestoreTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Handle(RestoreTask command)
        {
            var task = _taskRepository.First(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new TaskNotFoundException();

            task.Restore();
            _taskRepository.Update(task);
        }

        public async System.Threading.Tasks.Task HandleAsync(RestoreTask command)
        {
            var task = await _taskRepository.FirstAsync(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new TaskNotFoundException();

            task.Restore();
            await _taskRepository.UpdateAsync(task);
        }
    }
}
