using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToDict<T> : IConvertOperation<Dictionary<string, T>>
    {
        private IConvertOperation<T> valueOp;

        public ToDict(IConvertOperation<T> valueOp)
        {
            this.valueOp = valueOp;
        }

        public Dictionary<string, T> ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            var pairWise = new PairWise(node, path);
            var dict = new Dictionary<string, T>(pairWise.Count);
            foreach (var item in pairWise)
            {
                var value = valueOp.ConvertTo(item.value, item.path);
                if (!dict.TryAdd(item.key, value))
                    throw new ConversionException($"Duplicate key '{item.key}'", path, pairWise.Array);
            }
            return dict;
        }

        public static Dictionary<string, T> operator /(Query query, ToDict<T> op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
