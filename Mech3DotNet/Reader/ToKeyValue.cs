using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToKeyValue<T> : IConvertOperation<List<(string key, T value)>>
    {
        private IConvertOperation<T> valueOp;

        public ToKeyValue(IConvertOperation<T> valueOp)
        {
            this.valueOp = valueOp;
        }

        public List<(string key, T value)> ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            var pairWise = new PairWise(node, path);
            var list = new List<(string, T)>(pairWise.Count);
            foreach (var item in pairWise)
            {
                var value = valueOp.ConvertTo(item.value, item.path);
                list.Add((item.key, value));
            }
            return list;
        }

        public static List<(string key, T value)> operator /(Query query, ToKeyValue<T> op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
