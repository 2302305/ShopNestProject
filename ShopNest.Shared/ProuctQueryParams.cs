namespace ShopNest.Shared
{
    public class ProuctQueryParams
    {
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public string? search { get; set; }
        public ProductSortingOptions? Sort { get; set; }
        private int pageIndex = 1;

        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                pageIndex = (value <= 0) ? 1 : value;
            }
        }

        private const int defaultPageSize = 5;
        private const int MaximumPageSize = 10;
        private int pageSize = defaultPageSize;

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value <= 0)
                    pageSize = defaultPageSize;

                else if (value > MaximumPageSize)
                    pageSize = MaximumPageSize;

                else
                    pageSize = value;

            }
        }

    }
}