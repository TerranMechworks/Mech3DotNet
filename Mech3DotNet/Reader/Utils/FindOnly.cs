using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// An operation to unpack a single <see cref="ReaderValue"/> from a
    /// <see cref="ReaderList"/>.
    /// </summary>
    public struct FindOnly : IQueryOperation
    {
        /// <inheritdoc/>
        /// <returns>
        /// A single <see cref="ReaderValue"/>.
        /// </returns>
        /// <exception cref="ConversionException">
        /// Thrown if the reader value this operation is applied to is not a list.
        /// </exception>
        /// <exception cref="NotFoundException">
        /// Thrown if the list contains zero or more than one values.
        /// </exception>
        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            var list = ConversionException.List(value, path);
            if (list.Count != 1)
                throw new NotFoundException($"Single value not found (count: {list.Count})", path);
            path.Add(".only");
            return list[0];
        }
    }
}
