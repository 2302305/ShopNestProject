using ShopNest.Domain.Entities.ProductModule;
using ShopNest.Shared;

namespace ShopNet.Services.Specifications.ProductSpecifications
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product, int>
    {
        public ProductWithTypeAndBrandSpecification() : base(null!)
        {
            AddInclude(f => f.ProductBrand);
            AddInclude(f => f.ProductType);
        }
        public ProductWithTypeAndBrandSpecification(int id) : base(p => p.Id == id)
        {

            AddInclude(f => f.ProductBrand);
            AddInclude(f => f.ProductType);
        }
        public ProductWithTypeAndBrandSpecification(ProuctQueryParams prouctQueryParams)
            : base(ProductSpecificationHelper.GetCriteria(prouctQueryParams))
        {
            AddInclude(f => f.ProductBrand);
            AddInclude(f => f.ProductType);
            switch (prouctQueryParams.Sort)
            {
                case ProductSortingOptions.NameAscending:
                    AddOrderByAsc(a => a.Name);
                    break;
                case ProductSortingOptions.NameDescending:
                    AddOrderByDesc(a => a.Name);
                    break;
                case ProductSortingOptions.PriceAscending:
                    AddOrderByAsc(a => a.Price);
                    break;
                case ProductSortingOptions.PriceDescending:
                    AddOrderByDesc(a => a.Price);
                    break;
                default:
                    AddOrderByAsc(a => a.Id);
                    break;

            }
            ApplyPagination(prouctQueryParams.PageSize, prouctQueryParams.PageIndex);
        }
    }
}
