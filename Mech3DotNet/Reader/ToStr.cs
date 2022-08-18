using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct ToStr : IConvertOperation<string>
    {
        public static void ConvertExpected(IndexWise index, string expected)
        {
            var scalar = ConversionException.Scalar<ReaderString>(index.Current, index.Path, "Value is not a string");
            if (scalar.Value != expected)
                throw new ConversionException($"Expected '{expected}', got '{scalar.Value}'", index.Path, index.Underlying);
        }

        public static void ConvertExpected(ReaderValue value, IEnumerable<string> path, string expected, ReaderValue underlying)
        {
            var scalar = ConversionException.Scalar<ReaderString>(value, path, "Value is not a string");
            if (scalar.Value != expected)
                throw new ConversionException($"Expected '{expected}', got '{scalar.Value}'", path, underlying);
        }

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
            return op.ConvertTo(query._value, query._path);
        }
    }
}
