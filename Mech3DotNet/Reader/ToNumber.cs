using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToNumber : IConvertOperation<float>
    {
        public static float Convert(ReaderValue value, IEnumerable<string> path)
        {
            try
            {
                var scalar = ConversionException.Scalar<ReaderFloat>(value, path, "Value is not a number");
                return scalar.Value;
            }
            catch (ConversionException)
            {
                var scalar = ConversionException.Scalar<ReaderInt>(value, path, "Value is not a number");
                return (float)scalar.Value;
            }
        }

        public float ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static float operator /(Query query, ToNumber op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
