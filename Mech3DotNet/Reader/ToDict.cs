using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToDict<T> : IConvertOperation<Dictionary<string, T>>
    {
        private IConvertOperation<T> valueOp;

        public ToDict(IConvertOperation<T> valueOp)
        {
            this.valueOp = valueOp;
        }

        public Dictionary<string, T> ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var dict = new Dictionary<string, T>(pairWise.Count);
            foreach (var item in pairWise)
            {
                var res = valueOp.ConvertTo(item.value, item.path);
                if (!dict.TryAdd(item.key, res))
                    throw new ConversionException($"Duplicate key '{item.key}'", path, pairWise.Underlying);
            }
            return dict;
        }

        public static Dictionary<string, T> operator /(Query query, ToDict<T> op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
