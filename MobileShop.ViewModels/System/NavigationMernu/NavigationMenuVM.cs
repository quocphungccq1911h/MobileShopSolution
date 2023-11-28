namespace MobileShop.ViewModels.System.NavigationMernu
{
    public class NavigationMenuVM
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public NavigationMenuVM Items { get; set; }
    }
}
