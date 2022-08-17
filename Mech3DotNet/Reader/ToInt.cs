using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToInt : IConvertOperation<int>
    {
        public static int Convert(ReaderValue value, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar<ReaderInt>(value, path, "Value is not an int");
            return scalar.Value;
        }

        public int ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static int operator /(Query query, ToInt op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
