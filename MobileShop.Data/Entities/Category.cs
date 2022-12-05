using MobileShop.Data.Enum;

namespace MobileShop.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int SordOrder { get; set; }
        public bool IsShowHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
    }
}
