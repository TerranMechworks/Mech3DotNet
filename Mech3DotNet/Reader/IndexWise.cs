using System;
using System.Collections;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct IndexWise
    {
        private ReaderList _list;
        private int _index;
        private List<string> _path;

        public ReaderList Underlying => _list;
        public int Index => _index;
        public IEnumerable<string> Path => _path;
        public ReaderValue Current => _list[_index];
        public bool HasItems => _index < _list.Count;
        public ReaderValue? PeekNext
        {
            get
            {
                var next = _index + 1;
                if (next < _list.Count)
                    return _list[next];
                return null;
            }
        }

        public IndexWise(ReaderValue value, IEnumerable<string> path)
        {
            _list = ConversionException.List(value, path);
            _index = 0;
            _path = new List<string>(path);
            _path.Add(_index.ToString());
        }

        public IndexWise(ReaderValue value, IEnumerable<string> path, int count)
        {
            _list = ConversionException.ListFixed(value, path, count);
            _index = 0;
            _path = new List<string>(path);
            _path.Add(_index.ToString());
        }

        public IndexWise(ReaderValue value, IEnumerable<string> path, int min, int max)
        {
            _list = ConversionException.ListSized(value, path, min, max);
            _index = 0;
            _path = new List<string>(path);
            _path.Add(_index.ToString());
        }

        public void Next()
        {
            _index++;
            _path[_path.Count - 1] = _index.ToString();
        }
    }
}
