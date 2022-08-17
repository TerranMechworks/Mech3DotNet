using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToFloat : IConvertOperation<float>
    {
        public static float Convert(ReaderValue value, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar<ReaderFloat>(value, path, "Value is not a float");
            return scalar.Value;
        }

        public float ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static float operator /(Query query, ToFloat op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
