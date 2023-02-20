using MobileShop.ViewModels.System.Languages;
using System.Collections.Generic;

namespace MobileShop.AdminApp.Models
{
    public class NavigationVM
    {
        public List<LanguageVM> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
    }
}
