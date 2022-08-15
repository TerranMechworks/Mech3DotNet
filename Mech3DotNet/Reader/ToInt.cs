using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToInt : IConvertOperation<int>
    {
        public static int Convert(JsonNode? node, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar(node, path);
            if (scalar.TryGetValue<int>(out int value))
                return value;
            throw new ConversionException("Value is not an int", path, scalar);
        }

        public int ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            return Convert(node, path);
        }

        public static int operator /(Query query, ToInt op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
