using DM.Modules.Tasks.Application.Exceptions.Authors;
using DM.Modules.Tasks.Application.Specifications;
using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Factories.Authors;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Users.Shared.Events;
using DM.Shared.Application.Events;
using Task = System.Threading.Tasks.Task;

namespace DM.Modules.Tasks.Application.Events.Handlers
{
    internal class UserCreatedHandler : IEventHandler<UserCreated>
    {
        #region Dependencies

        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorFactory _authorFactory;

        #endregion

        public UserCreatedHandler(IAuthorFactory authorFactory, IAuthorRepository authorRepository)
            => (_authorFactory, _authorRepository) = (authorFactory, authorRepository);

        public void Handle(UserCreated @event)
        {
            if (_authorRepository.First(new ByIdSpecification<Author>(@event.UserId)) is not null)
                throw new AuthorExistsAlreadyException();

            var author = _authorFactory.Create(@event.UserId, @event.Login);
            _authorRepository.Create(author);
        }

        public async Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default)
        {
            if (_authorRepository.First(new ByIdSpecification<Author>(@event.UserId)) is not null)
                throw new AuthorExistsAlreadyException();

            var author = _authorFactory.Create(@event.UserId, @event.Login);
            await _authorRepository.CreateAsync(author);
        }
    }
}
