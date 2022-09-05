using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;
using EntityFrameworkCore.CommonTools;

namespace DM.Shared.Core.Repositories
{
    public interface ISearchable<TEntity> 
        where TEntity : AggregateRoot, IEntity
    {
        TEntity? First(ISpecification<TEntity> criteria);
        Task<TEntity?> FirstAsync(ISpecification<TEntity> criteria);
    }
}
