using System.Collections.Generic;

namespace Mech3DotNet.Reader.Mw
{
    public struct SatMap
    {
        public string name;
        public string bitmap;
        public float mpp;
        public Vec3 offset;

        public override string ToString() => $"SatMap<name='{name}', bitmap='{bitmap}', mpp={mpp}, offset={offset}>";
    }

    public struct ToSatMap : IConvertOperation<SatMap>
    {
        public static SatMap Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var satmap = new SatMap();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "name":
                        satmap.name = ToStr.Convert(item.value, item.path);
                        break;
                    case "bitmap":
                        satmap.bitmap = ToStr.Convert(item.value, item.path);
                        break;
                    case "mpp":
                        satmap.mpp = ToFloat.Convert(item.value, item.path);
                        break;
                    case "offset":
                        satmap.offset = ToVec3.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return satmap;
        }

        public SatMap ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SatMap operator /(Query query, ToSatMap op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
