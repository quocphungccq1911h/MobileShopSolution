using System.Collections.Generic;

namespace MobileShop.ViewModels.System.NavigationMernu
{
    public class NavigationMenuVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public List<NavigationMenuVM> Items { get; set; }
    }
}
