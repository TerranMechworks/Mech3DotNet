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
            var index = new IndexWise(value, path);
            var array = new T[index.Count];
            while (index.HasItems)
            {
                array[index.Index] = op.ConvertTo(index.Current, index.Path);
                index.Next();
            }
            return array;
        }

        public static T[] operator /(Query query, ToArray<T> op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
