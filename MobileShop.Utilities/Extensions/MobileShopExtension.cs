using System.Text.RegularExpressions;

namespace MobileShop.Utilities.Extensions
{
    public static class MobileShopExtension
    {
        public static string GenSlugHelper(string input)
        {
            // Convert to lowercase
            string slug = input.ToLowerInvariant();

            // Remove invalid characters
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            // Replace spaces with hyphens
            slug = slug.Replace(" ", "-");

            // Collapse consecutive hyphens into a single hyphen
            slug = Regex.Replace(slug, @"-+", "-");

            return slug;
        }
    }
}
