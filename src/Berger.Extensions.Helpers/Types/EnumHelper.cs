using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Berger.Extensions.Helpers
{
    public static class EnumHelper
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static T ToEnum<T>(this string value, T defaultValue)
        {
            if (!Enum.IsDefined(typeof(T), value))
                return defaultValue;

            return (T)Enum.Parse(typeof(T), value);
        }
        public static TDestination ToEnum<TDestination, TBaseEnum>(this TBaseEnum enumBase, TDestination defaultValue)
        {
            if (!Enum.IsDefined(typeof(TDestination), enumBase.ToString()))
                return defaultValue;

            return (TDestination)Enum.Parse(typeof(TDestination), enumBase.ToString());
        }
        public static string GetName(this Enum enumerator)
        {
            var attribute = GetAttribute(enumerator);

            return attribute != null ? attribute.Name : enumerator.ToString();
        }
        public static string GetDescription(this Enum enumerator)
        {
            var attribute = GetAttribute(enumerator);

            var output = string.Empty;

            if (attribute.Description != null)
                output = attribute.Description;

            else if (attribute.Name != null)
                output = attribute.Name;

            else
                output = enumerator.ToString();

            return output;
        }
        public static DisplayAttribute GetAttribute(object value)
        {
            if (value != null)
            {
                Type type = value.GetType();

                var field = type.GetField(value.ToString());

                return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
            }
            else
                return new DisplayAttribute { Description = "Not informed" };
        }
        public static string GetEnumDisplayName(this Enum value)
        {
            var information = value.GetType().GetField(value.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])information.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }
    }
}