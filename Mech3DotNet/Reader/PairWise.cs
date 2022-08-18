using System;
using System.Collections;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct PairWise : IEnumerable<(string key, ReaderValue value, IEnumerable<string> path)>
    {
        private ReaderList _list;
        private int _fullCount;
        private int _halfCount;
        private IEnumerable<string> _path;

        public int Count => _halfCount;
        public ReaderList Underlying => _list;

        public PairWise(ReaderValue value, IEnumerable<string> path)
        {
            _list = ConversionException.List(value, path);
            _path = path;

            _fullCount = _list.Count;
            _halfCount = _fullCount / 2;
            if (_halfCount * 2 != _fullCount)
                throw new ConversionException($"Value has uneven count {_fullCount}", path, _list);
        }

        public IEnumerator<(string key, ReaderValue value, IEnumerable<string> path)> GetEnumerator() => new PairWiseEnumerator(_list, _path, _fullCount);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public struct PairWiseEnumerator : IEnumerator<(string key, ReaderValue value, IEnumerable<string> path)>
    {
        private ReaderList _list;
        private int _count;
        private int _i;
        private int _j;

        private string _key;
        private ReaderValue _value;
        private List<string> _childPath;

        public PairWiseEnumerator(ReaderList list, IEnumerable<string> path, int count)
        {
            _list = list;
            _count = count;

            _i = 0 - 2;
            _j = 1 - 2;

            _key = string.Empty;
            _value = new ReaderInt(); // pick something for uninitialized value
            _childPath = new List<string>(path);
            _childPath.Add(""); // will be overwritten by loop index
        }

        public bool MoveNext()
        {
            _i += 2;
            _j += 2;
            if (_i >= _count)
                return false;

            _childPath[_childPath.Count - 1] = _i.ToString();
            _key = ToStr.Convert(_list[_i], _childPath);
            _childPath[_childPath.Count - 1] = _j.ToString();
            _value = _list[_j];
            return true;
        }

        public (string key, ReaderValue value, IEnumerable<string> path) Current
        {
            get { return (_key, _value, _childPath); }
        }

        object IEnumerator.Current => Current;

        public void Reset() => throw new NotSupportedException();
        void IDisposable.Dispose() { }
    }
}
