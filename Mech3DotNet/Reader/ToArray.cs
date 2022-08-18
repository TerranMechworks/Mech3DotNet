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

        public T[] ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            var list = ConversionException.List(value, path);
            var childPath = new List<string>(path);
            childPath.Add(""); // will be overwritten by loop index
            var array = new T[list.Count];
            for (var i = 0; i < list.Count; i++)
            {
                childPath[childPath.Count - 1] = i.ToString();
                array[i] = op.ConvertTo(list[i], childPath);
            }
            return array;
        }

        public static T[] operator /(Query query, ToArray<T> op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
