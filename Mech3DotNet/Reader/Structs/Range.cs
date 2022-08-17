using System.Collections.Generic;

namespace Mech3DotNet.Reader.Structs
{
    public struct Range
    {
        public float min;
        public float max;

        public override string ToString() => $"Range<min={min}, max={max}>";
    }

    public struct ToRange : IConvertOperation<Range>
    {
        public static Range Convert(ReaderValue value, IEnumerable<string> path)
        {
            var list = ConversionException.ListFixed(value, path, 2);
            var childPath = new IndexPath(path);
            var range = new Range();
            range.min = ToFloat.Convert(list[0], childPath.Path);
            childPath.Next();
            range.max = ToFloat.Convert(list[1], childPath.Path);
            return range;
        }

        public Range ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static Range operator /(Query query, ToRange op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
