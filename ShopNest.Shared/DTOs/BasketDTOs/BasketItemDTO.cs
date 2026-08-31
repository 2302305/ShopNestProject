using System.ComponentModel.DataAnnotations;

namespace ShopNest.Shared.DTOs.BasketDTOs
{
    public record BasketItemDTO(
        int Id,
        string? ProductName,
        string? PictureUrl,
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")] decimal Price,
       [Range(0, 100, ErrorMessage = "Quantity must be a non-negative value.")] int Quantity
        );

}