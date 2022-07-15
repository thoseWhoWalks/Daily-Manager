using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;

namespace DM.Modules.Tasks.Core.Aggregates
{
    public class TaskList : 
        IEntity,
        IAggregateRoot,
        IDeletableAggreagateRoot
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Guid AuthorId { get; }

        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime? DeletedAt { get; private set; }

        #region Navigation properties
        private List<Task> _tasks = new();
        /// <summary>
        /// Note: Using DTO required.
        /// </summary>
        public virtual IEnumerable<Task> Tasks => _tasks
            .AsReadOnly()
            .Where(t => !t.IsDeleted);
        #endregion

        #region Constructors
        private TaskList()
        {

        }

        public TaskList(Guid authorId, string title)
        {
            if (authorId == default)
                throw new ArgumentException(nameof(authorId));
            AuthorId = authorId;

            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public TaskList(Guid authorId, string title, string description) 
            : this(authorId, title)
        {
            Description = description;
        }

        public TaskList(Guid authorId, string title, string description, IEnumerable<Task> tasks) 
            : this(authorId, title, description)
        {
            Description = description;
            if (tasks is null || !tasks.Any()) throw new ArgumentException(nameof(tasks));
        }
        #endregion

        #region Invariants
        public void Rename(string title)
        {
            ArgumentNullException.ThrowIfNull(title);

            Title = title;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void AddTask(Task task)
        {
            ArgumentNullException.ThrowIfNull(task);

            _tasks.Add(task);
        }

        public void RemoveTask(Guid taskId)
        {
            if (taskId == default)
                throw new ArgumentOutOfRangeException(nameof(taskId));

            var task = _tasks.Single(t => t.Id == taskId);
            _tasks.Remove(task);
        }

        public void Delete()
        {
            if (_tasks.Any()) throw new InvalidOperationException();

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
        #endregion
    }
}
