using DM.Modules.Tasks.Application.Commands.TaskLists;
using DM.Modules.Tasks.Application.Exceptions.TaskLists;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Handlers.TaskLists
{
    internal class ChangeTaskListDescriptionHandler : ICommandHandler<ChangeTaskListDescription>
    {
        #region Dependencies

        private readonly ITaskListRepository _taskListRepository;

        #endregion

        public ChangeTaskListDescriptionHandler(ITaskListRepository taskRepository)
        {
            _taskListRepository = taskRepository;
        }

        public void Handle(ChangeTaskListDescription command)
        {
            var taskList = _taskListRepository.First(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new TaskListNotFoundException();

            taskList.ChangeDescription(command.description);
            _taskListRepository.Update(taskList);
        }

        public async System.Threading.Tasks.Task HandleAsync(ChangeTaskListDescription command)
        {
            var taskList = await _taskListRepository.FirstAsync(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new TaskListNotFoundException();

            taskList.ChangeDescription(command.description);
            await _taskListRepository.UpdateAsync(taskList);
        }
    }
}
