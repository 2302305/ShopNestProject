using ShopNest.Domain.Contracts.Specification;
using ShopNest.Domain.Entities;

namespace ShopNest.Presistence
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> entryPoint, ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            IQueryable<TEntity> Query = entryPoint;
            if (specifications is not null)
            {
                #region Condition
                //Where
                var condition = specifications.Criteria;
                if (condition is not null)
                {
                    Query = Query.Where(condition);
                }

                #endregion
                #region Include
                //Includes
                var specs = specifications.IncludeExpressions;
                if (specs is not null && specs.Count != 0)
                {
                    Query = specs.Aggregate(Query, (CurrentQuery, IncludeExp) =>
                    CurrentQuery.Include(IncludeExp)
                    );
                }

                #endregion
                #region Order
                //Order
                //Asc
                var OrderByAscExp = specifications.OrderByAsc;
                if (!(OrderByAscExp == null))
                {
                    Query = Query.OrderBy(OrderByAscExp);
                }
                //Desc
                var OrderByDescExp = specifications.OrderByDesc;
                if (!(OrderByDescExp == null))
                {
                    Query = Query.OrderByDescending(OrderByDescExp);
                }
                #endregion
                #region Pagination

                int Skip = specifications.Skip;
                int Take = specifications.Take;
                bool IsPaginated = specifications.IsPaginated;
                if (IsPaginated)
                {
                    Query = Query.Skip(Skip).Take(Take);
                }

                #endregion
            }
            return Query;
        }
    }
}
