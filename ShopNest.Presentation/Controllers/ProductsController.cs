using Microsoft.AspNetCore.Mvc;
using ShopNest.Services.Abstraction.Services;
using ShopNest.Shared;
using ShopNest.Shared.DTOs.ProductDTOs;

namespace ShopNest.Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        //GetALL
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDTO>>> GetAllProducts([FromQuery] ProuctQueryParams QueryParams)
        {
            var products = await productService.GetAllProductsAsync(QueryParams);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById([FromRoute] int id)
        {
            var product = await productService.GetProductByIdAsync(id)!;
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrandDTO>>> GetAllBrands()
        {
            var Brands = await productService.GetAllBrandsAsync();
            return Ok(Brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductTypeDTO>>> GetAllTypes()
        {
            var Types = await productService.GetAllTypesAsync();
            return Ok(Types);
        }

    }
}
