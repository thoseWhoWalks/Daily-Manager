using DM.Modules.Tasks.Application.Exceptions.Authors;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Users.Shared.Events;
using DM.Shared.Application.Events;
using Task = System.Threading.Tasks.Task;

namespace DM.Modules.Tasks.Application.Events.Handlers
{
    internal class UserDeletedHandler : IEventHandler<UserDeleted>
    {
        #region Dependencies

        private readonly IAuthorRepository _authorRepository;

        #endregion

        public UserDeletedHandler(IAuthorRepository authorRepository)
            => _authorRepository = authorRepository;

        public void Handle(UserDeleted @event)
        {
            var author = _authorRepository.First(new ByIdSpecification<Author>(@event.UserId));
            if (author is null)
                throw new AuthorNotFoundException();

            author.Delete();
            _authorRepository.Update(author);
        }

        public async Task HandleAsync(UserDeleted @event, CancellationToken cancellationToken = default)
        {
            var author = await _authorRepository.FirstAsync(new ByIdSpecification<Author>(@event.UserId));
            if (author is null)
                throw new AuthorNotFoundException();

            author.Delete();
            await _authorRepository.UpdateAsync(author);
        }
    }
}
