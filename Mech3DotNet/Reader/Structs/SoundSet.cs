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
            var list = ConversionException.List(value, path);
            var childPath = new IndexPath(path);
            var soundSet = new SoundSet()
            {
                definitions = new List<SoundDef>(),
            };
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item is ReaderString s && s.Value == "SUB_SET")
                {
                    var conv = List(String());
                    childPath.Next();
                    item = list[++i];
                    soundSet.subSets = conv.ConvertTo(item, childPath.Path);
                }
                else
                {
                    var def = ToSoundDef.Convert(item, childPath.Path);
                    soundSet.definitions.Add(def);
                }
                childPath.Next();
            }
            return soundSet;
        }

        public SoundSet ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SoundSet operator /(Query query, ToSoundSet op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
