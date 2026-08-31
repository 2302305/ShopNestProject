using ShopNest.Shared.DTOs.BasketDTOs;

namespace ShopNest.Services.Abstraction.ServiceAbstractions
{
    public interface IBasketService
    {
        Task<CustomerBasketDTO?> CreateOrUpdateBasketAsync(CustomerBasketDTO customerBasketDTO);
        Task<CustomerBasketDTO?> GetBasketByIdAsync(string basketId);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
