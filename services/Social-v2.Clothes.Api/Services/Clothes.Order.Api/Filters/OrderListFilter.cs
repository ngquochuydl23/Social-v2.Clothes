using Clothes.Commons.Filters;

namespace Clothes.Order.Api.Filters
{
    public class OrderListFilter: PaginationFilter
    {
        public string Status { get; set; }
    }
}
