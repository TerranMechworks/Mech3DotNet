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

        public T[] ConvertTo(JsonNode? element, IEnumerable<string> path)
        {
            if (element is null)
                throw new ConversionException("Element is null", path);

            if (element is JsonArray array)
            {
                var childPath = new List<string>(path);
                childPath.Add("");
                var list = new T[array.Count];
                for (var i = 0; i < array.Count; i++)
                {
                    childPath[childPath.Count - 1] = i.ToString();
                    list[i] = op.ConvertTo(array[i], childPath);
                }
                return list;
            }

            throw new ConversionException($"Element `{element}` is not an array", path);
        }

        public static T[] operator /(Query query, ToArray<T> op)
        {
            return op.ConvertTo(query.element, query.path);
        }
    }
}
