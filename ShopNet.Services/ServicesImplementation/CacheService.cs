using ShopNest.Domain.Contracts.RepositoryAbstraction;
using ShopNest.Services.Abstraction.ServiceAbstractions;
using System.Text.Json;

namespace ShopNet.Services.ServicesImplementation
{
    public class CacheService(ICacheRepository cacheRepository) : ICacheService
    {
        public async Task<string?> GetAsync(string CacheKey)
        {
            var Cache = await cacheRepository.GetAsync(CacheKey);

            return Cache ?? null;
        }

        public async Task SetAsync(string CacheKey, object Value, TimeSpan TimeToLive)
        {

            var ValueSerialize = JsonSerializer.Serialize(Value, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await cacheRepository.SetAsync(CacheKey, ValueSerialize, TimeToLive);
        }
    }
}
