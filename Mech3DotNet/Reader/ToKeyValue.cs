using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToKeyValue<T> : IConvertOperation<List<(string key, T value)>>
    {
        private IConvertOperation<T> valueOp;

        public ToKeyValue(IConvertOperation<T> valueOp)
        {
            this.valueOp = valueOp;
        }

        public List<(string key, T value)> ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var list = new List<(string, T)>(pairWise.Count);
            foreach (var item in pairWise)
            {
                var res = valueOp.ConvertTo(item.value, item.path);
                list.Add((item.key, res));
            }
            return list;
        }

        public static List<(string key, T value)> operator /(Query query, ToKeyValue<T> op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
