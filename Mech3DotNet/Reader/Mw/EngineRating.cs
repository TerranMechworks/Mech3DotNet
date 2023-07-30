using System.Collections.Generic;

namespace Mech3DotNet.Reader.Mw
{
    public struct EngineRating
    {
        public int min;
        public int max;

        public override string ToString() => $"EngineRating<min={min}, max={max}>";
    }

    public struct ToEngineRating : IConvertOperation<EngineRating>
    {
        public static EngineRating Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 2);
            var rating = new EngineRating();
            rating.min = ToInt.Convert(index.Current, index.Path);
            index.Next();
            rating.max = ToInt.Convert(index.Current, index.Path);
            return rating;
        }

        public EngineRating ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static EngineRating operator /(Query query, ToEngineRating op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
