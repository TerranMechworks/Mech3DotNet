using System.Collections.Generic;
using System.Text;

namespace Mech3DotNet.Reader.Structs
{
    public struct SoundDef
    {
        public string name;
        public string filename;
        public float volume;
        public bool purgeable;
        public bool voice;
        public bool queue;
        public bool looped;
        public bool threeD;
        public bool hardware;
        public Range? range;
        public string? subtitle;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("SoundDef<name='{0}', filename='{1}', volume={2}", name, filename, volume);
            if (purgeable)
                sb.Append(", purgeable");
            if (voice)
                sb.Append(", voice");
            if (queue)
                sb.Append(", queue");
            if (looped)
                sb.Append(", looped");
            if (threeD)
                sb.Append(", threeD");
            if (hardware)
                sb.Append(", hardware");
            if (range != null)
                sb.AppendFormat(", range={0}", range);
            if (subtitle != null)
                sb.AppendFormat(", subtitle='{0}'", subtitle);
            sb.Append('>');
            return sb.ToString();
        }
    }

    public struct ToSoundDef : IConvertOperation<SoundDef>
    {
        public static SoundDef Convert(ReaderValue value, IEnumerable<string> path)
        {
            var list = ConversionException.List(value, path);
            var childPath = new IndexPath(path);
            var soundDef = new SoundDef()
            {
                volume = 1.0f,
            };
            soundDef.name = ToStr.Convert(list[0], childPath.Path);
            childPath.Next();
            soundDef.filename = ToStr.Convert(list[1], childPath.Path);
            childPath.Next();
            for (var i = 2; i < list.Count; i++)
            {
                var item = list[i];
                // skip empty lists
                if (item is ReaderList nested_list && nested_list.Count == 0)
                    continue;

                var key = ToStr.Convert(item, childPath.Path);
                childPath.Next();
                switch (key)
                {
                    case "PURGEABLE":
                        soundDef.purgeable = true;
                        break;
                    case "VOICE":
                        soundDef.voice = true;
                        break;
                    case "QUEUE":
                        soundDef.queue = true;
                        break;
                    case "3D":
                        soundDef.threeD = true;
                        {
                            // this sound def is missing "RANGE"
                            if (soundDef.name == "wep_ams_fire" && list[i + 1] is ReaderList)
                            {
                                i++;
                                soundDef.range = ToRange.Convert(list[i], childPath.Path);
                                childPath.Next();
                            }
                        }
                        break;
                    case "LOOPED":
                        soundDef.looped = true;
                        break;
                    case "HARDWARE":
                        soundDef.hardware = true;
                        break;
                    case "VOICE_QUEUE":
                        // ???
                        soundDef.voice = true;
                        soundDef.queue = true;
                        break;
                    case "VOLUME":
                        i++;
                        soundDef.volume = ToFloat.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    case "RANGE":
                        i++;
                        soundDef.range = ToRange.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    case "SUBTITLE":
                        i++;
                        soundDef.subtitle = ToStr.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{key}'", childPath.Path, list);
                }
            }
            return soundDef;
        }

        public SoundDef ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SoundDef operator /(Query query, ToSoundDef op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
