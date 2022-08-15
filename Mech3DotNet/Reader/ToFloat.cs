using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToFloat : IConvertOperation<float>
    {
        public static float Convert(JsonNode? node, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar(node, path);
            if (scalar.TryGetValue<float>(out float value))
                return value;
            throw new ConversionException("Value is not a float", path, scalar);
        }

        public float ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            return Convert(node, path);
        }

        public static float operator /(Query query, ToFloat op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
