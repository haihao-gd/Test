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

        Task<IQueryable<TEntity>> IncludeRelatedAsync(params Expression<Func<TEntity, object>>[] propertySelectors);

        Task LoadRelatedAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>?>> propertyExpression, CancellationToken cancellationToken = default) where TProperty : class;

        Task LoadRelatedAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty?>> propertyExpression, CancellationToken cancellationToken = default) where TProperty : class;

        #endregion
    }
}
