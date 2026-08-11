using ShopNest.Domain.Contracts.Specification;
using ShopNest.Domain.Entities;
using System.Linq.Expressions;

namespace ShopNet.Services.Specifications
{
    public abstract class BaseSpecification<TEntity, TKey>(Expression<Func<TEntity, bool>> Criteria) : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        #region Condition
        public Expression<Func<TEntity, bool>> Criteria { get; } = Criteria;
        #endregion

        #region Pagination
        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginated { get; private set; }
        protected void ApplyPagination(int PageSize, int PageIndex)
        {
            IsPaginated = true;
            Take = PageSize;
            Skip = (PageIndex - 1) * PageSize;
            //Skip = (PageIndex-1)*Take;

        }
        #endregion

        #region Includes
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<TEntity, object>> IncludeExp)
        {
            IncludeExpressions.Add(IncludeExp);
        }
        #endregion

        #region Ordering

        public Expression<Func<TEntity, object>> OrderByAsc { private set; get; }

        public Expression<Func<TEntity, object>> OrderByDesc { private set; get; }
        protected void AddOrderByAsc(Expression<Func<TEntity, object>> OrderByAscExp)
        {
            OrderByAsc = OrderByAscExp;
        }
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExp)
        {
            OrderByDesc = OrderByDescExp;
        }
        #endregion
    }
}
