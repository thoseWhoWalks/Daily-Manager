using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;
using EntityFrameworkCore.CommonTools;

namespace DM.Shared.Core.Repositories
{
    public interface IFetchable<TEntity> 
        where TEntity : class, IEntity, IAggregateRoot
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(ISpecification<TEntity> criteria);
    }
}
