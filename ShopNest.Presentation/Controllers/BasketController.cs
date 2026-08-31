using Microsoft.AspNetCore.Mvc;
using ShopNest.Services.Abstraction.ServiceAbstractions;
using ShopNest.Shared.DTOs.BasketDTOs;

namespace ShopNest.Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IBasketService basketService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CustomerBasketDTO>> GetBasketAsync([FromQuery] string basketId)
        {
            var basket = await basketService.GetBasketByIdAsync(basketId);
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> CreateOrUpdateBasketAsync(CustomerBasketDTO customerBasketDTO)
        {
            var basket = await basketService.CreateOrUpdateBasketAsync(customerBasketDTO);
            return Ok(basket);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasketAsync([FromRoute] string id)
        {
            var result = await basketService.DeleteBasketAsync(id);
            return Ok(result);
        }
    }
}
