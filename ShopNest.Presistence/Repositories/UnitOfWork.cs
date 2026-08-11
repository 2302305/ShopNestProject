using ShopNest.Domain.Contracts;
using ShopNest.Domain.Contracts.RepositoryInterface;
using ShopNest.Domain.Entities;
using ShopNest.Presistence.Data.DbContexts;

namespace ShopNest.Presistence.Repositories
{
    public class UnitOfWork(StoreDbContext storeDbContext) : IUnitOfWork
    {
        private readonly Dictionary<Type, object> Repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var entityType = typeof(TEntity);
            if (Repositories.TryGetValue(entityType, value: out var repository))
            {
                return (IGenericRepository<TEntity, TKey>)repository;
            }
            var newRepo = new GenericRepository<TEntity, TKey>(storeDbContext);
            Repositories[entityType] = newRepo;
            return newRepo;
        }



        public async Task<int> SaveChangesAsync() => await storeDbContext.SaveChangesAsync();

    }
}
