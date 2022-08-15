
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using ToStr = Mech3DotNet.Reader.ToString;

namespace Mech3DotNet.Reader
{
    public struct PairWise : IEnumerable<(string key, JsonNode? value, IEnumerable<string> path)>
    {
        private JsonArray array;
        private int fullCount;
        private int halfCount;
        private IEnumerable<string> path;

        public int Count => halfCount;
        public JsonArray Array => array;

        public PairWise(JsonNode? node, IEnumerable<string> path)
        {
            array = ConversionException.Array(node, path);
            this.path = path;

            fullCount = array.Count;
            halfCount = fullCount / 2;
            if (halfCount * 2 != fullCount)
                throw new ConversionException($"Value has uneven count {fullCount}", path, array);
        }

        public IEnumerator<(string key, JsonNode? value, IEnumerable<string> path)> GetEnumerator() => new PairWiseEnumerator(array, path, fullCount);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public struct PairWiseEnumerator : IEnumerator<(string key, JsonNode? value, IEnumerable<string> path)>
    {
        private JsonArray array;
        private int count;
        private int i;
        private int j;

        private string key;
        private JsonNode? value;
        private List<string> childPath;

        public PairWiseEnumerator(JsonArray array, IEnumerable<string> path, int count)
        {
            this.array = array;
            this.count = count;

            i = 0 - 2;
            j = 1 - 2;

            key = string.Empty;
            value = null;
            childPath = new List<string>(path);
            childPath.Add(""); // will be overwritten by loop index
        }

        public bool MoveNext()
        {
            i += 2;
            j += 2;
            if (i >= count)
                return false;

            childPath[childPath.Count - 1] = i.ToString();
            key = ToStr.Convert(array[i], childPath);
            childPath[childPath.Count - 1] = j.ToString();
            value = array[j];
            return true;
        }

        public (string key, JsonNode? value, IEnumerable<string> path) Current
        {
            get { return (key, value, childPath); }
        }

        object IEnumerator.Current => Current;

        public void Reset() => throw new NotSupportedException();
        void IDisposable.Dispose() { }
    }
}
