using System.Collections.Generic;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Structs
{
    public struct SoundGroupExtra
    {
        public float min_delay;

        public override string ToString() => $"Extra<min_delay={min_delay}>";
    }

    public struct ToSoundGroupExtra : IConvertOperation<SoundGroupExtra>
    {
        public static SoundGroupExtra Convert(ReaderValue value, IEnumerable<string> path)
        {
            var list = ConversionException.List(value, path);
            var childPath = new IndexPath(path);
            var extra = new SoundGroupExtra();
            for (var i = 0; i < list.Count; i++)
            {
                var key = ToStr.Convert(list[i], childPath.Path);
                childPath.Next();
                switch (key)
                {
                    case "MINDELAY":
                        i++;
                        extra.min_delay = ToFloat.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{key}'", childPath.Path, list);
                }
            }
            return extra;
        }

        public SoundGroupExtra ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SoundGroupExtra operator /(Query query, ToSoundGroupExtra op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
