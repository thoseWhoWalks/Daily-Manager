using DM.Modules.Tasks.Application.Shared.Models.Tasks;
using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    public record AddTaskToTaskList(Guid id, TaskToCreateModel task) : ICommand;
}
