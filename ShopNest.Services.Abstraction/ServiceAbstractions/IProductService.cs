using ShopNest.Shared;
using ShopNest.Shared.DTOs.ProductDTOs;

namespace ShopNest.Services.Abstraction.Services
{
    public interface IProductService
    {
        Task<PaginatedResult<ProductDTO>> GetAllProductsAsync(ProuctQueryParams queryParams);
        Task<ProductDTO>? GetProductByIdAsync(int id);
        Task<IEnumerable<ProductBrandDTO>> GetAllBrandsAsync();
        Task<IEnumerable<ProductTypeDTO>> GetAllTypesAsync();
    }
}
