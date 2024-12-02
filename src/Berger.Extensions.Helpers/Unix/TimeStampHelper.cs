namespace Berger.Extensions.Helpers.Unix
{
    public static class TimeStampHelper
    {
        public static DateTimeOffset ConvertDateTime(DateTime timestamp)
        {
            return new DateTimeOffset(timestamp.ToUniversalTime());
        }
    }
}