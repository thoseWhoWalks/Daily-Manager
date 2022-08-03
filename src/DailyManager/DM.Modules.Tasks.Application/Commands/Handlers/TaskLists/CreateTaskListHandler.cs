using DM.Modules.Tasks.Application.Commands.TaskLists;
using DM.Modules.Tasks.Core.Factories.TaskLists;
using DM.Modules.Tasks.Core.Repositories;
using DM.Shared.Application.Commands;
using DM.Shared.Infrastructure.Authentication;

namespace DM.Modules.Tasks.Application.Commands.Handlers.TaskLists
{
    internal class CreateTaskListHandler : ICommandHandler<CreateTaskList>
    {
        #region Dependencies

        private readonly ITaskListRepository _taskListRepository;
        private readonly ITaskListFactory _taskListFactory;
        private readonly IUserContext _userContext;

        #endregion

        public CreateTaskListHandler(
            ITaskListRepository taskRepository,
            ITaskListFactory taskListFactory,
            IUserContext userContext
            )
        {
            _taskListRepository = taskRepository;
            _taskListFactory = taskListFactory;
            _userContext = userContext;
        }

        public void Handle(CreateTaskList command)
        {
            var taskList = _taskListFactory.Create(_userContext.UserId, command.title, 
                command.description);

            _taskListRepository.Create(taskList);
        }

        public async Task HandleAsync(CreateTaskList command)
        {
            var taskList = _taskListFactory.Create(_userContext.UserId, command.title,
                command.description);

            await _taskListRepository.CreateAsync(taskList);
        }
    }
}
