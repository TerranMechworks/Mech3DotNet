using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct FindByIndex : IQueryOperation
    {
        private int index;

        public FindByIndex(int index)
        {
            this.index = index;
        }

        public JsonNode? Apply(JsonNode? node, List<string> path)
        {
            var array = ConversionException.Array(node, path);

            var index = this.index;
            var count = array.Count;
            // allow negative indexing, i.e. from back of list
            if (index < 0)
                index = count + index;
            JsonNode? item;
            try
            {
                item = array[index];
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
