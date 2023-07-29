namespace Berger.Extensions.Helpers
{
    public static class PercentageHelper
    {
        public static decimal Calculate(decimal total, decimal sold)
        {
            var sum = total + sold;

            return Math.Round((total / sum) * 100, 0);
        }
    }
}