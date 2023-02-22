using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string Name { set; get; }
        public int CategoryId { get; set; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public string Description { set; get; } = string.Empty;
        public string Details { set; get; } = string.Empty;
        public string SeoDescription { set; get; } = string.Empty;
        public string SeoTitle { set; get; } = string.Empty;
        public string SeoAlias { get; set; } = string.Empty;
        public string LanguageId { set; get; }
        public bool? IsFeatured { get; set; }
        public IFormFile ThumbnailImage { get; set; }
        
    }
}
