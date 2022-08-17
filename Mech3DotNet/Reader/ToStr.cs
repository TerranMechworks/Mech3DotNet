using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToStr : IConvertOperation<string>
    {
        public static string Convert(ReaderValue value, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar<ReaderString>(value, path, "Value is not a string");
            return scalar.Value;
        }

        public string ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static string operator /(Query query, ToStr op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
