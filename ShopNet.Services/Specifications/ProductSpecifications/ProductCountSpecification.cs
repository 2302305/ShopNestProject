using ShopNest.Domain.Entities.ProductModule;
using ShopNest.Shared;

namespace ShopNet.Services.Specifications.ProductSpecifications
{
    public class ProductCountSpecification : BaseSpecification<Product, int>
    {
        public ProductCountSpecification(ProuctQueryParams prouctQueryParams) : base(ProductSpecificationHelper.GetCriteria(prouctQueryParams))
        {

        }
    }
}
