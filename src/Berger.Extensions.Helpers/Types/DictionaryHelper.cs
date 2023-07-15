namespace Berger.Extensions.Helpers
{
    public static class DictionaryHelper
    {
        public static void AddRangeOverride<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dictionary)
        {
            dictionary.ForEach(x => dic[x.Key] = x.Value);
        }
        public static void AddRangeNewOnly<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dictionary)
        {
            dictionary.ForEach(x => { if (!dic.ContainsKey(x.Key)) dic.Add(x.Key, x.Value); });
        }
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary is not null)
                dictionary.ForEach(x => dic.Add(x.Key, x.Value));
        }
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
        public static Dictionary<string, string> Parse(Dictionary<string, object> dictionary) =>
            dictionary is not null ? dictionary.ToDictionary(e => e.Key, e => e.Value.ToString()) : null;
        public static Dictionary<string, string> Parse(Dictionary<string, int> dictionary) =>
            dictionary is not null ? dictionary.ToDictionary(e => e.Key, e => e.Value.ToString() ?? string.Empty) : null;
    }
}