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
            var list = ConversionException.ListFixed(value, path, 3);
            var childPath = new IndexPath(path);
            var color = new Color();
            color.r = ToInt.Convert(list[0], childPath.Path);
            childPath.Next();
            color.g = ToInt.Convert(list[1], childPath.Path);
            childPath.Next();
            color.b = ToInt.Convert(list[2], childPath.Path);
            return color;
        }

        public Color ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static Color operator /(Query query, ToColor op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
