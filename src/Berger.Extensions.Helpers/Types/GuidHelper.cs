using System;

namespace Berger.Extensions.Helpers
{
    public static class GuidHelper
    {
        public static Guid ToGuid(this Guid? value)
        {
            return value ?? Guid.Empty;
        }
        public static Guid ToGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return Guid.Empty;

            return Guid.Parse(value);
        }
    }
}