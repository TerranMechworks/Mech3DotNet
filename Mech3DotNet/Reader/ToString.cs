using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToString : IConvertOperation<string>
    {
        public string ConvertTo(JsonNode? element, IEnumerable<string> path)
        {
            if (element is null)
                throw new ConversionException("Element is null", path);

            if (element is JsonValue direct_value)
            {
                string? value;
                if (direct_value.TryGetValue<string>(out value) && value != null)
                    return value;
            }
            else if (element is JsonArray array && array.Count == 1)
            {
                var only = array[0];
                if (only != null && only is JsonValue nested_value)
                {
                    string? value;
                    if (nested_value.TryGetValue<string>(out value) && value != null)
                        return value;
                }
            }

            throw new ConversionException($"Element `{element}` is not an string", path);
        }

        public static string operator /(Query query, ToString op)
        {
            return op.ConvertTo(query.element, query.path);
        }
    }
}
