namespace DM.Modules.Tasks.Application.Shared.Models.Tasks
{
    public class TaskToCreateModel
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime? ExecuteAt { get; set; }
    }
}
