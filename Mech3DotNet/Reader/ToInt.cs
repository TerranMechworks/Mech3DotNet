using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToInt : IConvertOperation<int>
    {
        public int ConvertTo(JsonNode? element, IEnumerable<string> path)
        {
            if (element is null)
                throw new ConversionException("Element is null", path);

            if (element is JsonValue direct_value)
            {
                int value;
                if (direct_value.TryGetValue<int>(out value))
                    return value;
            }
            else if (element is JsonArray array && array.Count == 1)
            {
                var only = array[0];
                if (only != null && only is JsonValue nested_value)
                {
                    int value;
                    if (nested_value.TryGetValue<int>(out value))
                        return value;
                }
            }

            throw new ConversionException($"Element `{element}` is not an int", path);
        }

        public static int operator /(Query query, ToInt op)
        {
            return op.ConvertTo(query.element, query.path);
        }
    }
}
