using System.Collections.Generic;
using System.Text;

namespace Mech3DotNet.Reader.Mw
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
            var index = new IndexWise(value, path);
            var soundDef = new SoundDef()
            {
                volume = 1.0f,
            };
            soundDef.name = ToStr.Convert(index.Current, index.Path);
            index.Next();
            soundDef.filename = ToStr.Convert(index.Current, index.Path);
            index.Next();
            while (index.HasItems)
            {
                // skip empty lists
                if (index.Current is ReaderList nested_list && nested_list.Count == 0)
                {
                    index.Next();
                    continue;
                }

                var key = ToStr.Convert(index.Current, index.Path);
                // do not advance index yet, since we might need index.Path to
                // throw an error
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
                            if (soundDef.name == "wep_ams_fire" && index.PeekNext is ReaderList)
                            {
                                index.Next();
                                soundDef.range = ToRange.Convert(index.Current, index.Path);
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
                        index.Next();
                        soundDef.volume = ToFloat.Convert(index.Current, index.Path);
                        break;
                    case "RANGE":
                        index.Next();
                        soundDef.range = ToRange.Convert(index.Current, index.Path);
                        break;
                    case "SUBTITLE":
                        index.Next();
                        soundDef.subtitle = ToStr.Convert(index.Current, index.Path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{key}'", index.Path, index.Underlying);
                }
                index.Next();
            }
            return soundDef;
        }

        public SoundDef ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SoundDef operator /(Query query, ToSoundDef op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
