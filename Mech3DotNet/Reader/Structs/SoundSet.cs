using System.Collections.Generic;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Structs
{
    public struct SoundSet
    {
        public List<SoundDef> definitions;
        public List<string>? subSets;
    }

    public struct ToSoundSet : IConvertOperation<SoundSet>
    {
        public static SoundSet Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path);
            var soundSet = new SoundSet()
            {
                definitions = new List<SoundDef>(),
            };
            while (index.HasItems)
            {
                if (index.Current is ReaderString s && s.Value == "SUB_SET")
                {
                    index.Next();
                    soundSet.subSets = ToList<string>.Convert(index.Current, index.Path, String());
                }
                else
                {
                    var def = ToSoundDef.Convert(index.Current, index.Path);
                    soundSet.definitions.Add(def);
                }
                index.Next();
            }
            return soundSet;
        }

        public SoundSet ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SoundSet operator /(Query query, ToSoundSet op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
