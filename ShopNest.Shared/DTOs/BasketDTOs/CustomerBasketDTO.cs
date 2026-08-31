using System.Collections.ObjectModel;

namespace ShopNest.Shared.DTOs.BasketDTOs
{
    public record CustomerBasketDTO(string? Id, Collection<BasketItemDTO> Items);

}
