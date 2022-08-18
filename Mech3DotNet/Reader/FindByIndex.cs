using System;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct FindByIndex : IQueryOperation
    {
        private int _index;

        public FindByIndex(int index)
        {
            _index = index;
        }

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
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFoundException($"Index '{_index}' not found (index: 0 <= {index} < {count})", path);
            }
            path.Add(_index.ToString());
            return item;
        }
    }
}
