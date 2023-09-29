using Catalog.Application.Requests.Common;

namespace Catalog.Application.Requests
{
    public class ProductRequest : PaginationRequest
    {
        public string Search { get; set; }
        public string SortColumn { get; set; }
        public string SortBy { get; set; }
    }
}
