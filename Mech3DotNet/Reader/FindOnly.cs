using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct FindOnly : IQueryOperation
    {
        public JsonNode? Apply(JsonNode? element, List<string> path)
        {
            var array = NotAnArrayException.Cast(element, path);

            if (array.Count < 1)
                throw new NotFoundException("Only item not found (no items)", path);

            if (array.Count > 1)
                throw new NotFoundException($"Only item not found ({array.Count} items)", path);

            path.Add(".only");
            return array[0];
        }
    }
}
