using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;
using DM.Shared.Core.Repositories;
using EntityFrameworkCore.CommonTools;
using Microsoft.EntityFrameworkCore;

namespace DM.Shared.Infrastructure.Repositories
{
    public abstract class CrudRepository<TEntity> :
        ICreateable<TEntity>,
        IUpdateable<TEntity>,
        ISearchable<TEntity>,
        IFetchable<TEntity>
        where TEntity : class, IEntity, IAggregateRoot
    {
        private readonly DbContext _dbContext;

        protected CrudRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Create(TEntity entity)
        {
            var entry = _dbContext.Add(entity);

            _dbContext.SaveChanges();
            return entry.Entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entry = await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var entry = _dbContext.Update(entity);

            _dbContext.SaveChanges();
            return entry.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = _dbContext.Update(entity);

            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public TEntity? First(ISpecification<TEntity> criteria)
        {
            var entry = _dbContext.Set<TEntity>()
                .FirstOrDefault(criteria.ToExpression());
            if (entry is null) return entry;

            _dbContext.Entry(entry).State =  EntityState.Detached;
            return entry;
        }

        public async Task<TEntity?> FirstAsync(ISpecification<TEntity> criteria)
        {
            var entry = await _dbContext.Set<TEntity>()
                .FirstOrDefaultAsync(criteria.ToExpression());
            if (entry is null) return entry;

            _dbContext.Entry(entry).State = EntityState.Detached;
            return entry;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>()
                .AsNoTracking();
        }

        public IQueryable<TEntity> GetAll(ISpecification<TEntity> criteria)
        {
           return _dbContext.Set<TEntity>()
                .Where(criteria.ToExpression())
                .AsNoTracking();
        }

        public virtual TEntity Delete(TEntity entity)
        {
            var entry = _dbContext.Set<TEntity>()
                .Remove(entity);

            _dbContext.SaveChanges();
            return entry.Entity;
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var entry = _dbContext.Set<TEntity>()
                .Remove(entity);

            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
