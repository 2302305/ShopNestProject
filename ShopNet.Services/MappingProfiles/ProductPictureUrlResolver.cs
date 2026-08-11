using AutoMapper;
using Microsoft.Extensions.Configuration;
using ShopNest.Domain.Entities.ProductModule;
using ShopNest.Shared.DTOs.ProductDTOs;

namespace ShopNet.Services.MappingProfiles
{
    public class ProductPictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDTO, string>
    {
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl)) return string.Empty;
            if (source.PictureUrl.StartsWith("http") || source.PictureUrl.StartsWith("https"))
                return source.PictureUrl;
            var baseUrl = configuration.GetSection("URLS")["BaseUrl"];
            var pictureUrl = $"{baseUrl}{source.PictureUrl}";
            return pictureUrl;
        }
    }
}
