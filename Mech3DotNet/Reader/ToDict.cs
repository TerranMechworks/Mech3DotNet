using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct ToDict<T> : IConvertOperation<Dictionary<string, T>>
    {
        private ToString keyOp;
        private IConvertOperation<T> valueOp;

        public ToDict(IConvertOperation<T> valueOp)
        {
            this.keyOp = new ToString();
            this.valueOp = valueOp;
        }

        public Dictionary<string, T> ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            var array = ConversionException.Array(node, path);

            var fullCount = array.Count;
            var halfCount = fullCount / 2;
            if (halfCount * 2 != fullCount)
                throw new ConversionException($"Value has uneven count {fullCount}", path, array);

            var childPath = new List<string>(path);
            childPath.Add(""); // will be overwritten by loop index

            var dict = new Dictionary<string, T>(halfCount);
            for (int i = 0, j = 1; i < fullCount; i += 2, j += 2)
            {
                childPath[childPath.Count - 1] = i.ToString();
                var key = keyOp.ConvertTo(array[i], childPath);
                childPath[childPath.Count - 1] = j.ToString();
                var value = valueOp.ConvertTo(array[j], childPath);
                if (!dict.TryAdd(key, value))
                    throw new ConversionException($"Duplicate key '{key}'", path, array);
            }
            return dict;
        }

        public static Dictionary<string, T> operator /(Query query, ToDict<T> op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
