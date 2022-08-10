using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct FindByKey : IQueryOperation
    {
        private string key;

        public FindByKey(string key)
        {
            this.key = key;
        }

        public JsonNode? Apply(JsonNode? element, List<string> path)
        {
            var array = NotAnArrayException.Cast(element, path);

            var found = new List<JsonNode?>();
            for (var i = 0; i < array.Count - 1; i++)
            {
                var child = array[i];
                string? childName;
                if (child is JsonValue value && value != null && value.TryGetValue<string>(out childName) && childName == key)
                {
                    var item = array[i + 1];
                    if (item == null)
                        throw new NotFoundException($"Key '{key}' not found (no value)", path);
                    // amazing! an existing item can't be added to a new array,
                    // because it already has a parent...
                    var copy = JsonNode.Parse(item.ToJsonString());
                    found.Add(copy);
                }
            }

            if (found.Count == 0)
                throw new NotFoundException($"Key '{key}' not found (no keys)", path);

            path.Add(key);
            return new JsonArray(found.ToArray());
        }
    }
}
