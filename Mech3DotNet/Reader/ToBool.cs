using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToBool : IConvertOperation<bool>
    {
        public static bool Convert(ReaderValue value, IEnumerable<string> path)
        {
            var scalar = ConversionException.Scalar<ReaderString>(value, path, "Value is not a boolean");
            // reader data does not have a data type for booleans
            switch (scalar.Value)
            {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    throw new ConversionException($"Value '{value}' is not a boolean", path, scalar);
            }
        }

        public bool ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static bool operator /(Query query, ToBool op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
