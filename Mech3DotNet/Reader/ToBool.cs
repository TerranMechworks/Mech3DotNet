using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToBool : IConvertOperation<bool>
    {
        public static bool Convert(JsonNode? node, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar(node, path);
            // reader data does not have a data type for booleans
            if (scalar.TryGetValue<string>(out string? value) && value != null)
            {
                switch (value)
                {
                    case "true":
                        return true;
                    case "false":
                        return false;
                    default:
                        throw new ConversionException($"Value '{value}' is not a bool", path, scalar);
                }
            }
            throw new ConversionException("Value is not a string (for bool)", path, scalar);
        }

        public bool ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            return Convert(node, path);
        }

        public static bool operator /(Query query, ToBool op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
