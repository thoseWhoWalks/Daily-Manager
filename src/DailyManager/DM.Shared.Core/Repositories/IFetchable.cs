using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;
using EntityFrameworkCore.CommonTools;

namespace DM.Shared.Core.Repositories
{
    public interface IFetchable<TEntity> 
        where TEntity : AggregateRoot, IEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(ISpecification<TEntity> criteria);
    }
}
