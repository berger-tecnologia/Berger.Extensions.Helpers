namespace Berger.Extensions.Helpers
{
    public static class UtcHelper
    {
        public static string ToUtc(this DateTime date, string zone)
        {
            return date.ToUtc(GetTimeZone(zone));
        }
        public static string ToUtc(this DateTime ? date, string zone)
        {
            var format = Format(date);

            return format.ToUtc(GetTimeZone(zone));
        }
        private static string ToUtc(this DateTime date, TimeZoneInfo zone)
        {
            if (date == DateTime.MinValue)
                return Messages.NotInformed;
            else
                return TimeZoneInfo.ConvertTimeFromUtc(date, zone).ToString();
        }
        private static DateTime Format(DateTime? date)
        {
            var format = DateTime.MinValue;

            if (date != null)
                format = (DateTime)date;

            return format;
        }
        private static TimeZoneInfo GetTimeZone(string zone)
        {
            if (zone == string.Empty)
                zone = UtcNames.PacificStandardTime;

            return TimeZoneInfo.FindSystemTimeZoneById(zone);
        }
    }
}