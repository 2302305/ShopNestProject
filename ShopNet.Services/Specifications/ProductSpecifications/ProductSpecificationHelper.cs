using ShopNest.Domain.Entities.ProductModule;
using ShopNest.Shared;
using System.Linq.Expressions;

namespace ShopNet.Services.Specifications.ProductSpecifications
{
    public static class ProductSpecificationHelper
    {
        public static Expression<Func<Product, bool>> GetCriteria(ProuctQueryParams prouctQueryParams)
        {
            return (p =>
            (!prouctQueryParams.brandId.HasValue || p.ProductBrandId == prouctQueryParams.brandId.Value)
            && (!prouctQueryParams.typeId.HasValue || p.ProductTypeId == prouctQueryParams.typeId.Value)
            && (string.IsNullOrEmpty(prouctQueryParams.search) || p.Name.ToLower().Contains(prouctQueryParams.search.ToLower())));
        }
    }
}
