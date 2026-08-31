using AutoMapper;
using ShopNest.Domain.Entities.ProductModule;
using ShopNest.Shared.DTOs.ProductDTOs;
using ShopNet.Services.MappingProfiles.PictureResolve;

namespace ShopNet.Services.MappingProfiles.ProductProfiles
{
    internal class ProductProfile : Profile
    {
        //Mapping and not for logic representation->Value Resolver 
        public ProductProfile()
        {
            CreateMap<ProductBrand, ProductBrandDTO>();
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductBrand, opt =>
                opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt =>
                opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductPictureUrlResolver>())
                //.ForMember(dest => dest.PictureUrl, opt =>
                //opt.MapFrom(src => $"{"https://localhost:7235"}/{src.PictureUrl}"));
                ;

        }
    }
}
