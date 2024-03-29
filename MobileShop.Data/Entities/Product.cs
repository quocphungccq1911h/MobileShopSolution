﻿using System;
using System.Collections.Generic;

namespace MobileShop.Data.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public bool? IsFeature { set; get; }
        public DateTime CreateDate { set; get; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        //public List<Product_Brand_Mapping> Product_Brand_Mappings { get; set; }
    }
}
