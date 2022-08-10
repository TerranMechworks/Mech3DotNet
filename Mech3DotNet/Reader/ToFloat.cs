using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToFloat : IConvertOperation<float>
    {
        public float ConvertTo(JsonNode? element, IEnumerable<string> path)
        {
            if (element is null)
                throw new ConversionException("Element is null", path);

            if (element is JsonValue direct_value)
            {
                float value;
                if (direct_value.TryGetValue<float>(out value))
                    return value;
            }
            else if (element is JsonArray array && array.Count == 1)
            {
                var only = array[0];
                if (only != null && only is JsonValue nested_value)
                {
                    float value;
                    if (nested_value.TryGetValue<float>(out value))
                        return value;
                }
            }

            throw new ConversionException($"Element `{element}` is not a float", path);
        }

        public static float operator /(Query query, ToFloat op)
        {
            return op.ConvertTo(query.element, query.path);
        }
    }
}
