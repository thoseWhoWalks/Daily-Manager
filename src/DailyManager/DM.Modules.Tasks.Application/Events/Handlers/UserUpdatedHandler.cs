using DM.Modules.Tasks.Application.Exceptions.Authors;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Users.Shared.Events;
using DM.Shared.Application.Events;
using Task = System.Threading.Tasks.Task;

namespace DM.Modules.Tasks.Application.Events.Handlers
{
    internal class UserUpdatedHandler : IEventHandler<UserUpdated>
    {
        #region Dependencies

        private readonly IAuthorRepository _authorRepository;

        #endregion

        public UserUpdatedHandler(IAuthorRepository authorRepository)
            => _authorRepository = authorRepository;

        public void Handle(UserUpdated @event)
        {
            var author = _authorRepository.First(new ByIdSpecification<Author>(@event.UserId));
            if (author is null)
                throw new AuthorNotFoundException();

            author.ChangeLogin(@event.Login);
            _authorRepository.Update(author);
        }

        public async Task HandleAsync(UserUpdated @event, CancellationToken cancellationToken = default)
        {
            var author = await _authorRepository.FirstAsync(new ByIdSpecification<Author>(@event.UserId));
            if (author is null)
                throw new AuthorNotFoundException();

            author.ChangeLogin(@event.Login);
            await _authorRepository.UpdateAsync(author);
        }
    }
}
