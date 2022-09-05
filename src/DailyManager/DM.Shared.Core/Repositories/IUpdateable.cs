using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;

namespace DM.Shared.Core.Repositories
{
    public interface IUpdateable<TEntity> 
        where TEntity : AggregateRoot, IEntity
    {
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
