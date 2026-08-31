namespace ShopNest.Services.Abstraction.ServiceAbstractions
{
    public interface ICacheService
    {
        Task<string?> GetAsync(string CacheKey);
        Task SetAsync(string CacheKey, object Value, TimeSpan TimeToLive);
    }
}
