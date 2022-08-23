using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToList<T> : IConvertOperation<List<T>>
    {
        private IConvertOperation<T> op;

        public ToList(IConvertOperation<T> op)
        {
            this.op = op;
        }

        public static List<T> Convert(ReaderValue value, IEnumerable<string> path, IConvertOperation<T> op)
        {
            var index = new IndexWise(value, path);
            var res = new List<T>(index.Count);
            while (index.HasItems)
            {
                res.Add(op.ConvertTo(index.Current, index.Path));
                index.Next();
            }
            return res;
        }

        public List<T> ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path, op);
        }

        public static List<T> operator /(Query query, ToList<T> op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
