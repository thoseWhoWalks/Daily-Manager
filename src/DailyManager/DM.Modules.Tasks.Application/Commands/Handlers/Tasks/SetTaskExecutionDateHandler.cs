using DM.Modules.Tasks.Application.Commands.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Commands.Handlers.Tasks
{
    internal class SetTaskExecutionDateHandler : ICommandHandler<SetTaskExecutionDate>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public SetTaskExecutionDateHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Handle(SetTaskExecutionDate command)
        {
            var task = _taskRepository.First(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new InvalidOperationException();

            task.SetExecutionDate(command.executionDate);
            _taskRepository.Update(task);
        }

        public async System.Threading.Tasks.Task HandleAsync(SetTaskExecutionDate command)
        {
            var task = await _taskRepository.FirstAsync(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new InvalidOperationException();

            task.SetExecutionDate(command.executionDate);
            await _taskRepository.UpdateAsync(task);
        }
    }
}
