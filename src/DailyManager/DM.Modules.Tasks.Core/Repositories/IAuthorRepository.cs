using DM.Modules.Tasks.Core.Aggregates;
using DM.Shared.Core.Repositories;

namespace DM.Modules.Tasks.Core.Repositories
{
    public interface IAuthorRepository :
        ICreateable<Author>,
        IUpdateable<Author>,
        ISearchable<Author>,
        IFetchable<Author>
    {
    }
}
