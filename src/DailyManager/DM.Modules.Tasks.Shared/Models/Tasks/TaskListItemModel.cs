using DM.Modules.Tasks.Core.Const;

namespace DM.Modules.Tasks.Shared.Models.Tasks
{
    public class TaskListItemModel
    {
        public string Title { get; set; } = null!;
        public TaskStates State { get; set; }
    }
}
