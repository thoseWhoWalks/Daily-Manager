using DM.Modules.Tasks.Application.Commands.TaskLists;
using DM.Modules.Tasks.Application.Exceptions.TaskLists;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Factories.Tasks;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;
using DM.Shared.Infrastructure.Authentication;

namespace DM.Modules.Tasks.Application.Commands.Handlers.TaskLists
{
    internal class AddTaskToTaskListHandler : ICommandHandler<AddTaskToTaskList>
    {
        #region Dependencies

        private readonly ITaskListRepository _taskListRepository;
        private readonly ITaskFactory _taskFactory;
        private readonly IUserContext _userContext;

        #endregion

        public AddTaskToTaskListHandler(
            ITaskListRepository taskRepository,
            ITaskFactory taskFactory,
            IUserContext userContext
            )
        {
            _taskListRepository = taskRepository;
            _taskFactory = taskFactory;
            _userContext = userContext;
        }

        public void Handle(AddTaskToTaskList command)
        {
            var taskList = _taskListRepository.First(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new TaskListNotFoundException();

            var task = _taskFactory.Create(_userContext.UserId, command.task.Title, 
                command.task.Description, command.task.ExecuteAt);
            taskList.AddTask(task);

            _taskListRepository.Update(taskList);
        }

        public async System.Threading.Tasks.Task HandleAsync(AddTaskToTaskList command)
        {
            var taskList = await _taskListRepository.FirstAsync(new ByIdSpecification<TaskList>(command.id));
            if (taskList is null)
                throw new TaskListNotFoundException();

            var task = _taskFactory.Create(_userContext.UserId, command.task.Title,
                command.task.Description, command.task.ExecuteAt);
            taskList.AddTask(task);

            await _taskListRepository.UpdateAsync(taskList);
        }
    }
}
