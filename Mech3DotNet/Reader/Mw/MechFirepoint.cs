using System.Collections.Generic;

namespace Mech3DotNet.Reader.Mw
{
    public struct MechFirepoint
    {
        public float radius;
        public float share;
        public string part;

        public override string ToString() => $"Firepoint<radius={radius}, share={share}, part='{part}'>";
    }

    public struct ToMechFirepoint : IConvertOperation<MechFirepoint>
    {
        public static MechFirepoint Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var firepoint = new MechFirepoint();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "radius":
                        firepoint.radius = ToFloat.Convert(item.value, item.path);
                        break;
                    case "share":
                        firepoint.share = ToFloat.Convert(item.value, item.path);
                        break;
                    case "part":
                        firepoint.part = ToStr.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return firepoint;
        }

        public MechFirepoint ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechFirepoint operator /(Query query, ToMechFirepoint op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
