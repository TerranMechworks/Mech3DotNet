using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToList<T> : IConvertOperation<List<T>>
    {
        private IConvertOperation<T> op;

        public ToList(IConvertOperation<T> op)
        {
            this.op = op;
        }

        public List<T> ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            var array = ConversionException.Array(node, path);
            var childPath = new List<string>(path);
            childPath.Add(""); // will be overwritten by loop index
            var list = new List<T>(array.Count);
            for (var i = 0; i < array.Count; i++)
            {
                childPath[childPath.Count - 1] = i.ToString();
                list.Add(op.ConvertTo(array[i], childPath));
            }
            return list;
        }

        public static List<T> operator /(Query query, ToList<T> op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
