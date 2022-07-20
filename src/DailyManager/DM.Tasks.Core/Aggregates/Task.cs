using DM.Modules.Tasks.Core.Const;
using DM.Modules.Tasks.Core.Exceptions.Tasks;
using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;

namespace DM.Modules.Tasks.Core.Aggregates
{
    public class Task :
        IEntity,
        IAggregateRoot,
        IDeletableAggreagateRoot
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Guid ListId { get; }
        public Guid AuthorId { get; }

        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public TaskStates State { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime? DeletedAt { get; private set; }
        public DateTime? ExecuteAt { get; private set; }
        public DateTime? ExecutedAt { get; private set; }

        #region Constructors
        private Task()
        {

        }

        internal Task(Guid authorId,  Guid listId, string title, string? description, DateTime? executeAt)
        {
            if (authorId == default)
                throw new CreateTaskWithoutAuthorException();
            AuthorId = authorId;

            if (listId == default)
                throw new CreateTaskOutOfListContextException();
            ListId = listId;

            if (executeAt.HasValue && executeAt <= DateTime.UtcNow)
                throw new CreateTaskWithOverdueExecutionDateException();
            ExecuteAt = executeAt;

            Title = title ?? throw new CreateTaskWithoutTitleException();
            Description = description;
        }
        #endregion

        #region Invariants
        public void Rename(string title)
        {
            if (IsDeleted)
                throw new TaskDeletedException(Title);

            Title = title ?? throw new RenameTaskToEmptyTitleException();
        }

        public void ChangeDescription(string description)
        {
            if (IsDeleted)
                throw new TaskDeletedException(Title);

            Description = description;
        }

        public void ChangeExecutionDate(DateTime? date)
        {
            if (IsDeleted)
                throw new TaskDeletedException(Title);

            if (!date.HasValue && State == TaskStates.Overdue)
                State = TaskStates.Active;
            if (date > DateTime.UtcNow && State == TaskStates.Overdue)
                State = TaskStates.Active;
            if (date <= DateTime.UtcNow && State == TaskStates.Active)
                State = TaskStates.Overdue;

            ExecuteAt = date;
        }

        public void SetExecutionDate(DateTime date)
        {
            if (IsDeleted)
                throw new TaskDeletedException(Title);

            if (State != TaskStates.Executed && date <= DateTime.UtcNow)
                throw new OverdueTaskExecutionDateModifyException();
            ExecuteAt = date;
        }

        public void Execute()
        {
            if (IsDeleted)
                throw new TaskDeletedException(Title);
            if (State == TaskStates.Executed)
                throw new ExecutedTaskExecutionException();

            State = TaskStates.Executed;
            ExecutedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new TaskDeletedException(Title);

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public void Restore()
        {
            if (!IsDeleted)
                throw new NotDeletedTaskRestoreException();

            IsDeleted = false;
            DeletedAt = null;
        }
        #endregion
    }
}
