using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;

namespace DM.Shared.Core.Repositories
{
    public interface IDeleteable<TEntity> 
        where TEntity : class, IEntity, IAggregateRoot
    {
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
