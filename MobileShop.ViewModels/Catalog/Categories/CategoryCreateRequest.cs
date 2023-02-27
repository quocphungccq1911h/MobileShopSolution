using MobileShop.Data.Enum;

namespace MobileShop.ViewModels.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        public int SortOrder { get; set; }
        public bool IsShowHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }
    }
}
