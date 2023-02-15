using Microsoft.AspNetCore.Mvc;
using MobileShop.ViewModels.Common;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
