namespace MobileShop.Data.Entities
{
    public class NavigationMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
    }
}
