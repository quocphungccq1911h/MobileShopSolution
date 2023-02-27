using System.ComponentModel.DataAnnotations;

namespace MobileShop.Data.Enum
{
    public enum Status
    {
        [Display(Name = "Not active")]
        InActive,
        [Display(Name = "Active")]
        Active
    }
}
