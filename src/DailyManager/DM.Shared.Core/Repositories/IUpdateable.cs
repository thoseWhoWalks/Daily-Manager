using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;

namespace DM.Shared.Core.Repositories
{
    public interface IUpdateable<TEntity> 
        where TEntity : class, IEntity, IAggregateRoot
    {
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
