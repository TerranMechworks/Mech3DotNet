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
            var index = new IndexWise(value, path, 2);
            var range = new Range();
            range.min = ToFloat.Convert(index.Current, index.Path);
            index.Next();
            range.max = ToFloat.Convert(index.Current, index.Path);
            return range;
        }

        public Range ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static Range operator /(Query query, ToRange op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
