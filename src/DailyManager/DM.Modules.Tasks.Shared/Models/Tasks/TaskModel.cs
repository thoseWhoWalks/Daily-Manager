using DM.Modules.Tasks.Core.Const;

namespace DM.Modules.Tasks.Shared.Models.Tasks
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public TaskStates State { get; set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? ExecuteAt { get; set; }
        public DateTime? ExecutedAt { get; set; }
    }
}
