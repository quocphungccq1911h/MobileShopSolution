using Microsoft.EntityFrameworkCore;
using MobileShop.Data;
using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly MobileShopDbContext _context;
        public LanguageService(MobileShopDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<List<LanguageVM>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVM()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVM>>(languages);
        }
    }
}
