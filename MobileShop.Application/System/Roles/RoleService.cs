using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobileShop.Data.Entities;
using MobileShop.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<RoleVM>> GetAll()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleVM()
            {
                Id = x.Id,
                Decription = x.Description,
                Name = x.Name
            }).ToListAsync();
            return roles;
        }
    }
}
