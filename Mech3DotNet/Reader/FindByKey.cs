using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// An operation to find one or more <see cref="ReaderValue"/> by key in a
    /// <see cref="ReaderList"/>.
    ///
    /// This operation returns multiple values. Each value is the next index
    /// of the key.
    /// </summary>
    public struct FindByKey : IQueryOperation
    {
        private string _key;

        public FindByKey(string key)
        {
            _key = key;
        }

        /// <inheritdoc/>
        /// <returns>
        /// A <see cref="ReaderList"/> with one or more values.
        /// </returns>
        /// <exception cref="ConversionException">
        /// Thrown if the reader value this operation is applied to is not a list.
        /// </exception>
        /// <exception cref="NotFoundException">
        /// Thrown if no keys are found in the list.
        /// </exception>
        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            var list = ConversionException.List(value, path);

            var found = new List<ReaderValue>();
            for (var i = 0; i < list.Count - 1; i++)
            {
                var child = list[i];
                if (child is ReaderString str && _key == str.Value)
                    found.Add(list[i + 1]);
            }

            if (found.Count == 0)
                throw new NotFoundException($"Key '{_key}' not found (no keys)", path);

            path.Add(_key);
            return new ReaderList(found);
        }
    }
}
