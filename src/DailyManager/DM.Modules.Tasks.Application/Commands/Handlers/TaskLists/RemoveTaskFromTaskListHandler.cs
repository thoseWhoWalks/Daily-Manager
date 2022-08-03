using DM.Modules.Tasks.Application.Commands.TaskLists;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Handlers.TaskLists
{
    internal class RemoveTaskFromTaskListHandler : ICommandHandler<RemoveTaskFromTaskList>
    {
        #region Dependencies

        private readonly ITaskListRepository _taskListRepository;

        #endregion

        public RemoveTaskFromTaskListHandler(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public void Handle(RemoveTaskFromTaskList command)
        {
            var taskList = _taskListRepository.First(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new InvalidOperationException();

            taskList.RemoveTask(command.taskId);
            _taskListRepository.Update(taskList);
        }

        public async System.Threading.Tasks.Task HandleAsync(RemoveTaskFromTaskList command)
        {
            var taskList = await _taskListRepository.FirstAsync(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new InvalidOperationException();

            taskList.RemoveTask(command.taskId);
            await _taskListRepository.UpdateAsync(taskList);
        }
    }
}
