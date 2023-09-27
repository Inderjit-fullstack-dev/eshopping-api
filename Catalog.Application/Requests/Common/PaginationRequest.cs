namespace Catalog.Application.Requests.Common
{
    public class PaginationRequest
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
