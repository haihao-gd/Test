using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Domain.Entities;

namespace ZeroStack.DeviceCenter.Domain.Repositories
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Related Navigation Property

        /// <summary>
        /// Specifies related entities to include in the query results. The navigation property to be included is specified starting with the type of entity being queried.
        /// </summary>
        Task<IQueryable<TEntity>> IncludeRelatedAsync(params Expression<Func<TEntity, object?>>[] propertySelectors);

        /// <summary>
        /// Provides access to change tracking and loading information for a collection navigation property that associates this entity to a collection of another entities.
        /// </summary>
        Task LoadRelatedAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression, CancellationToken cancellationToken = default) where TProperty : class;

        /// <summary>
        /// Provides access to change tracking and loading information for a reference (i.e. non-collection) navigation property that associates this entity to another entity.
        /// </summary>
        Task LoadRelatedAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty?>> propertyExpression, CancellationToken cancellationToken = default) where TProperty : class;

        #endregion
    }
}
