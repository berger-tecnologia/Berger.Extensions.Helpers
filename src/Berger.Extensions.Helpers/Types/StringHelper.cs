using System.Text.RegularExpressions;

namespace Berger.Extensions.Helpers
{
    public static class StringHelper
    {
        public static string RemoveSpecial(this string text)
        {
            if (!string.IsNullOrEmpty(text))
                return Regex.Replace(text, @"[^\w\d\s]", "");

            return string.Empty;
        }
        public static string RemoveAccents(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string input = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
                string output = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

                for (int i = 0; i < input.Length; i++)
                    text = text.Replace(input[i].ToString(), output[i].ToString());

                return text;
            }

            return string.Empty;
        }
        public static string ToCamelCase(this string value)
        {
            return char.ToLower(value[0]) + value.Substring(1);
        }
        public static string ToPlural(this string value)
        {
            return $"{value}s";
        }
    }
}