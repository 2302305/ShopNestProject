using ShopNest.Domain.Contracts.RepositoryAbstraction;
using StackExchange.Redis;

namespace ShopNest.Presistence.Repositories
{
    public class CacheRepository(IConnectionMultiplexer connectionMultiplexer) : ICacheRepository
    {
        private readonly IDatabase database = connectionMultiplexer.GetDatabase();

        public async Task<string?> GetAsync(string CacheKey)
        {
            var CacheValue = await database.StringGetAsync(CacheKey);
            if (CacheValue.IsNullOrEmpty)
            {
                return null;
            }
            return CacheValue.ToString();
        }

        public async Task SetAsync(string CacheKey, string Value, TimeSpan TimeToLive)
        {
            await database.StringSetAsync(CacheKey, Value, TimeToLive);
        }
    }
}
