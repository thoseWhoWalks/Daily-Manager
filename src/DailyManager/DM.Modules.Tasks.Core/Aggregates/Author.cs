using DM.Modules.Tasks.Core.Exceptions.Authors;
using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;

namespace DM.Modules.Tasks.Core.Aggregates
{
    public class Author :
        AggregateRoot,
        IEntity,
        IDeletableAggreagateRoot
    {
        public Guid Id { get; private set; }

        public string Login { get; private set; } = null!;

        public bool IsDeleted { get; private set; }

        public DateTime? DeletedAt { get; private set; }

        #region Constructors
        private Author()
        {

        }

        public Author(Guid id, string login)
        {
            if(id == default)
                throw new CreateAuthorWithoutIdException();

            Login = login ?? throw new CreateAuthorWithoutLoginException();
        }
        #endregion

        #region Invariants
        public void Delete()
        {
            if (IsDeleted is true)
                throw new AuthorDeletedException(Login);

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
        #endregion
    }
}
