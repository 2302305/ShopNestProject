using ShopNest.Domain.Entities;
using System.Linq.Expressions;

namespace ShopNest.Domain.Contracts.Specification
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        public Expression<Func<TEntity, bool>> Criteria { get; }
        public Expression<Func<TEntity, object>> OrderByAsc { get; }
        public Expression<Func<TEntity, object>> OrderByDesc { get; }
        public int Skip { get; }
        public int Take { get; }
        public bool IsPaginated { get; }
    }
}
