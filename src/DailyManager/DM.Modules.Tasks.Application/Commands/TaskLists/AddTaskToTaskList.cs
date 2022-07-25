using DM.Modules.Tasks.Application.Models.Tasks;
using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    internal record AddTaskToTaskList(Guid id, TaskToCreateModel task) : ICommand;
}
