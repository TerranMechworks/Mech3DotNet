using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToArray<T> : IConvertOperation<T[]>
    {
        private IConvertOperation<T> op;

        public ToArray(IConvertOperation<T> op)
        {
            this.op = op;
        }

        public T[] ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            var array = ConversionException.Array(node, path);
            var childPath = new List<string>(path);
            childPath.Add(""); // will be overwritten by loop index
            var list = new T[array.Count];
            for (var i = 0; i < array.Count; i++)
            {
                childPath[childPath.Count - 1] = i.ToString();
                list[i] = op.ConvertTo(array[i], childPath);
            }
            return list;
        }

        public static T[] operator /(Query query, ToArray<T> op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
