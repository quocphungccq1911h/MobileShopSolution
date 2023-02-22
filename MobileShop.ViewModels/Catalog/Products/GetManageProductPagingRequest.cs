using MobileShop.ViewModels.Common;
using System.Collections.Generic;

namespace MobileShop.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
        public List<int> CategoryIds { get; set; }
        public int? CategoryId { get; set; }
    }
}
