using System;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct FindByIndex : IQueryOperation
    {
        private int index;

        public FindByIndex(int index)
        {
            this.index = index;
        }

        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            var list = ConversionException.List(value, path);

            var index = this.index;
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
                throw new NotFoundException($"Index '{this.index}' not found (index: 0 <= {index} < {count})", path);
            }
            path.Add(this.index.ToString());
            return item;
        }
    }
}
