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
            var list = ConversionException.List(value, path);
            var childPath = new List<string>(path);
            childPath.Add(""); // will be overwritten by loop index
            var res = new List<T>(list.Count);
            for (var i = 0; i < list.Count; i++)
            {
                childPath[childPath.Count - 1] = i.ToString();
                res.Add(op.ConvertTo(list[i], childPath));
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
