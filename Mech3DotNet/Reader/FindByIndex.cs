using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// An operation to find a single <see cref="ReaderValue"/> by index in a
    /// <see cref="ReaderList"/>.
    ///
    /// The index may be negative, in which case the index is calculated from
    /// the back of the array.
    /// </summary>
    public struct FindByIndex : IQueryOperation
    {
        private int _index;

        public FindByIndex(int index)
        {
            _index = index;
        }

        /// <inheritdoc/>
        /// <returns>
        /// A single <see cref="ReaderValue"/> at the specified index.
        /// </returns>
        /// <exception cref="ConversionException">
        /// Thrown if the reader value this operation is applied to is not an array.
        /// </exception>
        /// <exception cref="NotFoundException">
        /// Thrown if the index is out of range.
        /// </exception>
        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            var list = ConversionException.List(value, path);

            var index = _index;
            var count = list.Count;
            // allow negative indexing, i.e. from back of list
            if (index < 0)
                index = count + index;
            ReaderValue item;
            try
            {
                item = list[index];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw new NotFoundException($"Index '{_index}' not found (index: 0 <= {index} < {count})", path);
            }
            path.Add(_index.ToString());
            return item;
        }
    }
}
