using MobileShop.ViewModels.Common;

namespace MobileShop.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
