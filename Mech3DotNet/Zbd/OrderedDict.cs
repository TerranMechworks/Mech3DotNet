using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Mech3DotNet.Zbd
{
    public class OrderedDict<TValue> : IEnumerable<KeyValuePair<string, TValue>>
    {
        private OrderedDictionary inner;

        public OrderedDict()
        {
            inner = new OrderedDictionary();
        }

        public int Count { get => inner.Count; }
        public TValue this[string key] { get => (TValue)inner[key]; set => inner[key] = value; }
        public TValue this[int index] { get => (TValue)inner[index]; }

        public void Add(string key, TValue value) => inner.Add(key, value);
        public void Clear() => inner.Clear();
        public bool ContainsKey(string key) => inner.Contains(key);
        public void Remove(string key) => inner.Remove(key);

        public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator()
        {
            var it = inner.GetEnumerator();
            while (it.MoveNext())
            {
                var key = (string)it.Key;
                var val = (TValue)it.Value;
                yield return KeyValuePair.Create(key, val);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
