using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader.Structs
{
    public struct Color
    {
        public int r;
        public int g;
        public int b;

        public override string ToString() => $"Color<r={r}, g={g}, b={b}>";
    }

    public struct ToColor: IConvertOperation<Color>
    {
        public static Color Convert(JsonNode? node, IEnumerable<string> path)
        {
            var array = ConversionException.ArrayFixed(node, path, 3);
            var childPath = new List<string>(path);
            childPath.Add("0");
            var color = new Color();
            color.r = ToInt.Convert(array[0], childPath);
            childPath[childPath.Count - 1] = "1";
            color.g = ToInt.Convert(array[1], childPath);
            childPath[childPath.Count - 1] = "2";
            color.b = ToInt.Convert(array[2], childPath);
            return color;
        }

        public Color ConvertTo(JsonNode? node, IEnumerable<string> path)
        {
            return Convert(node, path);
        }

        public static Color operator /(Query query, ToColor op)
        {
            return op.ConvertTo(query.node, query.path);
        }
    }
}
