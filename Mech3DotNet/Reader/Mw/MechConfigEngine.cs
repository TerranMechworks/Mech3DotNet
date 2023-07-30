using System.Collections.Generic;

namespace Mech3DotNet.Reader.Mw
{
    public struct MechConfigEngine
    {
        public int rating;
        public bool xl;
        public float maxSpeed;

        public override string ToString() => $"Engine<rating={rating}, xl={xl}, max_speed={maxSpeed}>";
    }

    public struct ToMechConfigEngine : IConvertOperation<MechConfigEngine>
    {
        public static MechConfigEngine Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var engine = new MechConfigEngine();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "rating":
                        engine.rating = ToInt.Convert(item.value, item.path);
                        break;
                    case "xl":
                        engine.xl = ToBool.Convert(item.value, item.path);
                        break;
                    case "max_speed":
                        engine.maxSpeed = ToFloat.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return engine;
        }

        public MechConfigEngine ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechConfigEngine operator /(Query query, ToMechConfigEngine op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
