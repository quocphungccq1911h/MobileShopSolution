using System;
using System.Collections.Generic;
using System.Text;

namespace MobileShop.Data.Entities
{
    public class ProductTranslation
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; } = string.Empty;
        public string Details { set; get; } = string.Empty;
        public string SeoDescription { set; get; } = string.Empty;
        public string SeoTitle { set; get; } = string.Empty;
        public string SeoAlias { get; set; } = string.Empty;
        public string LanguageId { set; get; }
        public Product Product { get; set; }
        public Language Language { get; set; }

    }
}
