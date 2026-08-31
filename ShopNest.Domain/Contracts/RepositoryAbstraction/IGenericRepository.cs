using ShopNest.Domain.Contracts.Specification;
using ShopNest.Domain.Entities;

namespace ShopNest.Domain.Contracts.RepositoryInterface
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        //Add-Update-Delete-GetAll-GetById
        //1-GetById
        Task<TEntity?> GetByIdAsync(TKey id);
        //6-GetByIdWithSpecs
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications);
        //2-Get All
        Task<IEnumerable<TEntity>> GetAllAsync();
        //-5 GEtAllWithSpecification
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications);
        //3-Add
        Task AddAsync(TEntity entity);
        //4-Update
        void Update(TEntity entity);
        //4-Delete
        void Delete(TEntity entity);
        //Count
        Task<int> CountAsync(ISpecifications<TEntity, TKey> specifications);
    }
}
