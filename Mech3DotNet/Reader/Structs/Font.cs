using System.Collections.Generic;

namespace Mech3DotNet.Reader.Structs
{
    public struct Font
    {
        public string face;
        public int height;
        public Color color;
        public bool shadow;
        public string align;

        public override string ToString() => $"Font<face='{face}', height={height}, color={color}, shadow={shadow}, align='{align}'>";
    }

    public struct ToFont : IConvertOperation<Font>
    {
        public static Font Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var font = new Font();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "face":
                        font.face = ToStr.Convert(item.value, item.path);
                        break;
                    case "height":
                        font.height = ToInt.Convert(item.value, item.path);
                        break;
                    case "color":
                        font.color = ToColor.Convert(item.value, item.path);
                        break;
                    case "shadow":
                        font.shadow = ToBool.Convert(item.value, item.path);
                        break;
                    case "align":
                        font.align = ToStr.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return font;
        }

        public Font ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static Font operator /(Query query, ToFont op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
