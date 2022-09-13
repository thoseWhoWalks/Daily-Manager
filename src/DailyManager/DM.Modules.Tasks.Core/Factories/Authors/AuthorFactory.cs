using DM.Modules.Tasks.Core.Aggregates;

namespace DM.Modules.Tasks.Core.Factories.Authors
{
    public class AuthorFactory : IAuthorFactory
    {
        public Author Create(Guid id, string login)
            => new(id, login);
    }
}
