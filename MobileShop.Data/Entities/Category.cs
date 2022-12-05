using MobileShop.Data.Enum;
using System.Collections.Generic;

namespace MobileShop.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int SordOrder { get; set; }
        public bool IsShowHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
