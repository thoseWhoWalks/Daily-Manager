using DM.Modules.Tasks.Application.Commands.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Commands.Handlers.Tasks
{
    internal class ChangeTaskDescriptionHandler : ICommandHandler<ChangeTaskDescription>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public ChangeTaskDescriptionHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Handle(ChangeTaskDescription command)
        {
            var task = _taskRepository.First(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new InvalidOperationException();

            task.ChangeDescription(command.description);
            _taskRepository.Update(task);
        }

        public async System.Threading.Tasks.Task HandleAsync(ChangeTaskDescription command)
        {
            var task = await _taskRepository.FirstAsync(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new InvalidOperationException();

            task.ChangeDescription(command.description);
            await _taskRepository.UpdateAsync(task);
        }
    }
}
