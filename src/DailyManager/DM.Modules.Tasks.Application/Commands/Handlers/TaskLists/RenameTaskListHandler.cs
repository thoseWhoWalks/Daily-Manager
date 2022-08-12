using DM.Modules.Tasks.Application.Commands.TaskLists;
using DM.Modules.Tasks.Application.Exceptions.TaskLists;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.Handlers.TaskLists
{
    internal class RenameTaskListHandler : ICommandHandler<RenameTaskList>
    {
        #region Dependencies

        private readonly ITaskListRepository _taskListRepository;

        #endregion

        public RenameTaskListHandler(ITaskListRepository taskRepository)
        {
            _taskListRepository = taskRepository;
        }

        public void Handle(RenameTaskList command)
        {
            var taskList = _taskListRepository.First(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new TaskListNotFoundException();

            taskList.Rename(command.title);
            _taskListRepository.Update(taskList);
        }

        public async System.Threading.Tasks.Task HandleAsync(RenameTaskList command)
        {
            var taskList = await _taskListRepository.FirstAsync(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new TaskListNotFoundException();

            taskList.Rename(command.title);
            await _taskListRepository.UpdateAsync(taskList);
        }
    }
}
