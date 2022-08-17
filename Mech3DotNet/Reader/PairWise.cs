
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct PairWise : IEnumerable<(string key, ReaderValue value, IEnumerable<string> path)>
    {
        private ReaderList list;
        private int fullCount;
        private int halfCount;
        private IEnumerable<string> path;

        public int Count => halfCount;
        public ReaderList Underlying => list;

        public PairWise(ReaderValue value, IEnumerable<string> path)
        {
            list = ConversionException.List(value, path);
            this.path = path;

            fullCount = list.Count;
            halfCount = fullCount / 2;
            if (halfCount * 2 != fullCount)
                throw new ConversionException($"Value has uneven count {fullCount}", path, list);
        }

        public IEnumerator<(string key, ReaderValue value, IEnumerable<string> path)> GetEnumerator() => new PairWiseEnumerator(list, path, fullCount);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public struct PairWiseEnumerator : IEnumerator<(string key, ReaderValue value, IEnumerable<string> path)>
    {
        private ReaderList list;
        private int count;
        private int i;
        private int j;

        private string key;
        private ReaderValue value;
        private List<string> childPath;

        public PairWiseEnumerator(ReaderList list, IEnumerable<string> path, int count)
        {
            this.list = list;
            this.count = count;

            i = 0 - 2;
            j = 1 - 2;

            key = string.Empty;
            value = new ReaderInt(); // pick something for uninitialized value
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
            key = ToStr.Convert(list[i], childPath);
            childPath[childPath.Count - 1] = j.ToString();
            value = list[j];
            return true;
        }

        public (string key, ReaderValue value, IEnumerable<string> path) Current
        {
            get { return (key, value, childPath); }
        }

        object IEnumerator.Current => Current;

        public void Reset() => throw new NotSupportedException();
        void IDisposable.Dispose() { }
    }
}
