using ShopNest.Domain.Contracts.RepositoryInterface;
using ShopNest.Domain.Contracts.Specification;
using ShopNest.Domain.Entities;
using ShopNest.Presistence.Data.DbContexts;

namespace ShopNest.Presistence.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext storeDbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity) => await storeDbContext.Set<TEntity>().AddAsync(entity);


        public async Task<IEnumerable<TEntity>> GetAllAsync() => await storeDbContext.Set<TEntity>().ToListAsync();


        public async Task<TEntity?> GetByIdAsync(TKey id) => await storeDbContext.Set<TEntity>().FindAsync(id);


        public void Update(TEntity entity) => storeDbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => storeDbContext.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications)
        {
            var entryPoint = storeDbContext.Set<TEntity>();
            var Query = SpecificationEvaluator.CreateQuery<TEntity, TKey>(entryPoint, specifications);
            return await Query.ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications)
        {
            var Entity = storeDbContext.Set<TEntity>();
            var Query = SpecificationEvaluator.CreateQuery<TEntity, TKey>(Entity, specifications);
            return await Query.FirstOrDefaultAsync();
        }

        public Task<int> CountAsync(ISpecifications<TEntity, TKey> specifications)
        {
            var entryPoint = storeDbContext.Set<TEntity>();
            var Query = SpecificationEvaluator.CreateQuery(entryPoint, specifications);
            return Query.CountAsync();
        }
    }
}
