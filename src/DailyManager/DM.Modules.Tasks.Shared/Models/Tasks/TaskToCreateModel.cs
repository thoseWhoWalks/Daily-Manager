namespace DM.Modules.Tasks.Application.Shared.Models.Tasks
{
    internal class TaskToCreateModel
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime? ExecuteAt { get; set; }
    }
}
