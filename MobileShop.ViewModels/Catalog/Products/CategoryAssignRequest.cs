using MobileShop.ViewModels.Common;
using System.Collections.Generic;

namespace MobileShop.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public  List<SeletedItem> Categories { get; set; } = new List<SeletedItem>();
    }
}
