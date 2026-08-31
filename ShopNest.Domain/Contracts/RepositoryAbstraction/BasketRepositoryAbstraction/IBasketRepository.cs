using ShopNest.Domain.Entities.BasketModule;

namespace ShopNest.Domain.Contracts.RepositoryAbstraction.BasketRepositoryAbstraction
{
    public interface IBasketRepository
    {
        public Task<CustomerBasket?> GetBasketAsync(string basketId);
        public Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket customerBasket, TimeSpan TimeToLive = default);
        public Task<bool> DeleteBasketAsync(string basketId);
    }
}
