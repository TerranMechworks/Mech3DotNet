using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// Enumerate all <see cref="ReaderValue"/> in a <see cref="ReaderList"/>.
    /// </summary>
    public struct IndexWise
    {
        private ReaderList _list;
        private int _index;
        private List<string> _path;

        /// <summary>Returns the underlying <see cref="ReaderList"/>.</summary>
        public ReaderList Underlying => _list;
        /// <summary>Returns the current index of the item in the list.</summary>
        public int Index => _index;
        /// <summary>Returns the count of items in the list.</summary>
        public int Count => _list.Count;
        /// <summary>Returns the current path of the item in the list.</summary>
        public IEnumerable<string> Path => _path;
        /// <summary>Returns the current item in the list.</summary>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Thrown if the index has been advanced past the end of the list.
        /// </exception>
        public ReaderValue Current => _list[_index];
        /// <summary>
        /// Returns <see langword="true"/> if there are remaining items in the
        /// list.
        /// </summary>
        public bool HasItems => _index < _list.Count;
        /// <summary>
        /// Returns the next item in the list if it exists or
        /// <see langword="null"/>, without advancing the index.
        /// </summary>
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

        /// <summary>
        /// Create a new index-wise iteration over the specified
        /// <see cref="ReaderValue"/> with an existing query path.
        /// </summary>
        /// <exception cref="ConversionException">
        /// Thrown if the <see cref="ReaderValue"/> is not a
        /// <see cref="ReaderList"/>.
        /// </exception>
        public IndexWise(ReaderValue value, IEnumerable<string> path)
        {
            _list = ConversionException.List(value, path);
            _index = 0;
            _path = new List<string>(path);
            _path.Add(_index.ToString());
        }

        /// <summary>
        /// Create a new index-wise iteration over the specified
        /// <see cref="ReaderValue"/> with an existing query path.
        /// </summary>
        /// <exception cref="ConversionException">
        /// Thrown if the <see cref="ReaderValue"/> is not a
        /// <see cref="ReaderList"/>, or the list has fewer or more items than
        /// the expected count.
        /// </exception>
        public IndexWise(ReaderValue value, IEnumerable<string> path, int count)
        {
            _list = ConversionException.ListFixed(value, path, count);
            _index = 0;
            _path = new List<string>(path);
            _path.Add(_index.ToString());
        }

        /// <summary>
        /// Create a new index-wise iteration over the specified
        /// <see cref="ReaderValue"/> with an existing query path.
        /// </summary>
        /// <exception cref="ConversionException">
        /// Thrown if the <see cref="ReaderValue"/> is not a
        /// <see cref="ReaderList"/>, or the list has fewer items than the
        /// expected minimum, or the list has more items than the expected
        /// maximum.
        /// </exception>
        public IndexWise(ReaderValue value, IEnumerable<string> path, int min, int max)
        {
            _list = ConversionException.ListSized(value, path, min, max);
            _index = 0;
            _path = new List<string>(path);
            _path.Add(_index.ToString());
        }

        /// <summary>Advance to the next index.</summary>
        public void Next()
        {
            _index++;
            _path[_path.Count - 1] = _index.ToString();
        }
    }
}
