using DM.Modules.Tasks.Core.Exceptions.TaskLists;
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

        internal TaskList(Guid authorId, string title)
        {
            if (authorId == default)
                throw new CreateTaskListWithoutAuthorException();
            AuthorId = authorId;

            Title = title ?? throw new CreateTaskListWithoutTitleException();
        }

        internal TaskList(Guid authorId, string title, string description)
            : this(authorId, title)
        {
            Description = description;
        }

        internal TaskList(Guid authorId, string title, string description, IEnumerable<Task> tasks)
            : this(authorId, title, description)
        {
            Description = description;
            if (tasks is null || !tasks.Any())
                throw new CreateTaskListWithPredefinedTasksWithoutAnyTaskException();

            _tasks.AddRange(tasks);
        }
        #endregion

        #region Invariants
        public void Rename(string title)
        {
            Title = title ?? throw new RenameTaskListToEmptyTitleException();
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void AddTask(Task task)
        {
            if (task is null)
                throw new AddNullTaskToTaskListException();

            _tasks.Add(task);
        }

        public void RemoveTask(Guid taskId)
        {
            if (taskId == default)
                throw new RemoveTaskFromTaskListByInvalidIdException();

            var task = _tasks.Single(t => t.Id == taskId);
            _tasks.Remove(task);
        }

        public void Delete()
        {
            if (_tasks.Any(t => !t.IsDeleted))
                throw new DeleteTaskListWithTasksException();

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
        #endregion
    }
}
