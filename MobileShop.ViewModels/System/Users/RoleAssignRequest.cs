using MobileShop.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace MobileShop.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SeletedItem> Roles { get; set; } = new List<SeletedItem>();
    }
}
