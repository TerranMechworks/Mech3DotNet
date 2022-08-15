using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct FindOnly : IQueryOperation
    {
        public JsonNode? Apply(JsonNode? node, List<string> path)
        {
            var array = ConversionException.Array(node, path);
            if (array.Count != 1)
                throw new NotFoundException($"Single value not found (count: {array.Count})", path);
            path.Add(".only");
            return array[0];
        }
    }
}
