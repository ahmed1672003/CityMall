using CityMall.Specifications.Contracts;
using CityMall.Specifications.Specifications;

namespace CityMall.Infrastructure.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ICityMallDbContext _context;
    protected readonly DbSet<TEntity> _entities;

    public Repository(ICityMallDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }
    #region Commands
    public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellation = default)
    {
        await _entities.AddAsync(entity, cancellation);
    }

    public virtual async Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
    {
        await _entities.BulkInsertOptimizedAsync(entities, options =>
        {
            options.AcceptAllChangesOnSuccess = true;
        }, cancellation);
    }
    public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _entities.Update(entity);
        return Task.CompletedTask;
    }
    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _entities.BulkUpdateAsync(entities, options =>
        {
            options.AcceptAllChangesOnSuccess = true;
        }, cancellationToken);
    }

    public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_entities.Remove(entity));
    }

    public virtual Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _entities.RemoveRange(entities);
        return Task.CompletedTask;
    }
    public virtual async Task<int> ExecuteDeleteAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)

    {
        if (specification?.Criteria is null)
            return await _entities.ExecuteDeleteAsync(cancellationToken);
        else
            return await _entities.Where(specification.Criteria).ExecuteDeleteAsync(cancellationToken);
    }
    #endregion

    #region Queries
    public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).AnyAsync(cancellationToken);
    }

    public virtual async Task<bool> AllAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).AllAsync(specification.Criteria);
    }

    public virtual async Task<int> CountAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).CountAsync(cancellationToken);
    }

    public virtual Task<IQueryable<TEntity>> RetrieveAllAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(SpecificationEvaluator.GetQuery(_entities, specification));
    }

    public virtual async Task<TEntity> RetrieveAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).FirstOrDefaultAsync();
    }
    #endregion
}
