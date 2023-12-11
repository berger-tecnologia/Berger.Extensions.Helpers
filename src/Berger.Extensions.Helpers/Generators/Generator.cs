namespace Berger.Extensions.Helpers
{
    public static class Generator
    {
        private static Random random = new Random();

        public static string Create(int size = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}