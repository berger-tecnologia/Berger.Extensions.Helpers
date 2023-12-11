using System.Globalization;

namespace Berger.Extensions.Helpers
{
    public static class CurrencyHelper
    {
        public static string ToCurrency(this decimal value)
        {
            var cultureCode = "pt-BR";

            try
            {
                CultureInfo culture = new CultureInfo(cultureCode);

                return string.Format(culture, "{0:C}", value);
            }
            catch (CultureNotFoundException)
            {
                return "Invalid culture code.";
            }
        }
    }
}