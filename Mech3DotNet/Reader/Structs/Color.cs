using System.Collections.Generic;

namespace Mech3DotNet.Reader.Structs
{
    public struct Color
    {
        public int r;
        public int g;
        public int b;

        public override string ToString() => $"Color<r={r}, g={g}, b={b}>";
    }

    public struct ToColor : IConvertOperation<Color>
    {
        public static Color Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 3);
            var color = new Color();
            color.r = ToInt.Convert(index.Current, index.Path);
            index.Next();
            color.g = ToInt.Convert(index.Current, index.Path);
            index.Next();
            color.b = ToInt.Convert(index.Current, index.Path);
            return color;
        }

        public Color ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static Color operator /(Query query, ToColor op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
