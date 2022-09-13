using DM.Modules.Tasks.Core.Aggregates;

namespace DM.Modules.Tasks.Core.Factories.Authors
{
    public interface IAuthorFactory  
    {
        Author Create(Guid id, string login);
    }
}
