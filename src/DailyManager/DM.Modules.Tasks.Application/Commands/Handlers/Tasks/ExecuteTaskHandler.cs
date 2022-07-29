using DM.Modules.Tasks.Application.Commands.Tasks;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Commands.Handlers.Tasks
{
    internal class ExecuteTaskHandler : ICommandHandler<ExecuteTask>
    {
        #region Dependencies

        private readonly ITaskRepository _taskRepository;

        #endregion

        public ExecuteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Handle(ExecuteTask command)
        {
            var task = _taskRepository.First(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new InvalidOperationException();

            task.Execute();
            _taskRepository.Update(task);
        }

        public async System.Threading.Tasks.Task HandleAsync(ExecuteTask command)
        {
            var task = await _taskRepository.FirstAsync(new ByIdSpecification<Task>(command.id));
            if (task is null)
                throw new InvalidOperationException();

            task.Execute();
            await _taskRepository.UpdateAsync(task);
        }
    }
}
