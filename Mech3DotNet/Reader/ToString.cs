using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToString : IConvertOperation<string>
    {
        public static string Convert(JsonNode? node, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar(node, path);
            if (scalar.TryGetValue<string>(out string? value) && value != null)
                return value;
            throw new ConversionException("Value is not a string", path, scalar);
        }

        public string ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            return Convert(node, path);
        }

        public static string operator /(Query query, ToString op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
