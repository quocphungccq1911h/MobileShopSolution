using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MobileShop.Utilities.Extensions
{
    public static class MobileShopExtension
    {
        #region Methods
        public static string GenSlugHelper(string input)
        {
            // Normalize the string and remove diacritics
            string normalized = RemoveDiacritics(input.ToLower());

            // Replace non-alphanumeric characters with a dash
            string slug = Regex.Replace(normalized, @"[^a-z0-9]+", "-");

            // Remove leading and trailing dashes
            slug = slug.Trim('-');

            return slug;
        }
        #endregion

        #region Helpers
        private static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }
        #endregion
    }
}
