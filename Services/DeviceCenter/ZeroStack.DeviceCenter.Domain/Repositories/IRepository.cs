using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Domain.Entities;
using ZeroStack.DeviceCenter.Domain.Specifications;
using ZeroStack.DeviceCenter.Domain.UnitOfWork;

namespace ZeroStack.DeviceCenter.Domain.Repositories
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> InsertAsync([NotNull] TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteAsync([NotNull] TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteAsync([NotNull] Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync([NotNull] TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetListAsync(bool includeRelated = false, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, object>> sorting, bool includeRelated = false, CancellationToken cancellationToken = default);

        Task<TEntity?> FindAsync([NotNull] Expression<Func<TEntity, bool>> predicate, bool includeRelated = true, CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync([NotNull] Expression<Func<TEntity, bool>> predicate, bool includeRelated = true, CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<List<TResult>> GetListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<TResult> GetAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default);

        IQueryable<TEntity> Query { get; }

        IUnitOfWork UnitOfWork { get; }

        IAsyncQueryableProvider AsyncExecuter { get; }
    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : BaseEntity<TKey>
    {
        Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(TKey id, bool includeRelated = true, CancellationToken cancellationToken = default);

        Task<TEntity?> FindAsync(TKey id, bool includeRelated = true, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default);
    }
}