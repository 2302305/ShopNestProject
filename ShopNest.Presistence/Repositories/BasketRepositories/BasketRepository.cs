using ShopNest.Domain.Contracts.RepositoryAbstraction.BasketRepositoryAbstraction;
using ShopNest.Domain.Entities.BasketModule;
using StackExchange.Redis;
using System.Text.Json;

namespace ShopNest.Presistence.Repositories.BasketRepositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase database;
        public BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            database = connectionMultiplexer.GetDatabase();
        }
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket customerBasket, TimeSpan TimeToLive = default)
        {
            var jsonBasket = JsonSerializer.Serialize(customerBasket);
            var IsCreatedOrUpdated = await database.StringSetAsync(customerBasket.Id, jsonBasket, (TimeToLive == default) ? TimeSpan.FromDays(7) : TimeToLive);
            return await GetBasketAsync(customerBasket.Id);
        }

        public async Task<bool> DeleteBasketAsync(string basketId) => await database.KeyDeleteAsync(basketId);
        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            var Basket = await database.StringGetAsync(basketId);
            if (Basket.IsNullOrEmpty)
                return null;
            else
                return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
        }
    }
}
