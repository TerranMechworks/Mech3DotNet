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

        public List<T> ConvertTo(JsonNode? element, IEnumerable<string> path)
        {
            if (element is null)
                throw new ConversionException("Element is null", path);

            if (element is JsonArray array)
            {
                var childPath = new List<string>(path);
                childPath.Add("");
                var list = new List<T>(array.Count);
                for (var i = 0; i < array.Count; i++)
                {
                    childPath[childPath.Count - 1] = i.ToString();
                    var item = op.ConvertTo(array[i], childPath);
                    list.Add(item);
                }
                return list;
            }

            throw new ConversionException($"Element `{element}` is not an array", path);
        }

        public static List<T> operator /(Query query, ToList<T> op)
        {
            return op.ConvertTo(query.element, query.path);
        }
    }
}
