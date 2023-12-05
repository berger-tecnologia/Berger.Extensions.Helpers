using System.Globalization;

namespace Berger.Extensions.Helpers
{
    public static class CurrencyHelper
    {
        public static string ToCurrency(this decimal amount, string code)
        {
            try
            {
                CultureInfo culture = new CultureInfo(code);

                return amount.ToString("C", culture);
            }
            catch (CultureNotFoundException)
            {
                return "Invalid culture code.";
            }
        }
    }
}