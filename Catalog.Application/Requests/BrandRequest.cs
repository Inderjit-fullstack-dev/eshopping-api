using Catalog.Application.Requests.Common;

namespace Catalog.Application.Requests
{
    public class BrandRequest : PaginationRequest
    {
        public string Keyword { get; set; }
    }
}
