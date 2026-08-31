namespace ShopNest.Domain.Contracts.RepositoryAbstraction
{
    public interface ICacheRepository
    {
        //Get Data From Cache
        Task<string?> GetAsync(string CacheKey);
        //Set Data Into Cache
        Task SetAsync(string CacheKey, string Value, TimeSpan TimeToLive);
    }
}
