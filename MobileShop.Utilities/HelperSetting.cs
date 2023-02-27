using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MobileShop.Utilities
{
    public class HelperSetting
    {
        public static string GetDisplayName(Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }
    }
}
