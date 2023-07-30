using System.Collections.Generic;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Mw
{
    public struct SoundGroupExtra
    {
        public float minDelay;

        public override string ToString() => $"Extra<min_delay={minDelay}>";
    }

    public struct ToSoundGroupExtra : IConvertOperation<SoundGroupExtra>
    {
        public static SoundGroupExtra Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path);
            var extra = new SoundGroupExtra();
            while (index.HasItems)
            {
                var key = ToStr.Convert(index.Current, index.Path);
                // do not advance index yet, since we might need index.Path to
                // throw an error
                switch (key)
                {
                    case "MINDELAY":
                        index.Next();
                        extra.minDelay = ToFloat.Convert(index.Current, index.Path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{key}'", index.Path, index.Underlying);
                }
                index.Next();
            }
            return extra;
        }

        public SoundGroupExtra ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SoundGroupExtra operator /(Query query, ToSoundGroupExtra op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
