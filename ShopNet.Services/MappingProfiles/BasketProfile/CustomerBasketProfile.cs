using AutoMapper;
using ShopNest.Domain.Entities.BasketModule;
using ShopNest.Shared.DTOs.BasketDTOs;

namespace ShopNet.Services.MappingProfiles.BasketProfile
{
    public class CustomerBasketProfile : Profile
    {
        public CustomerBasketProfile()
        {
            CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
        }
    }
}
