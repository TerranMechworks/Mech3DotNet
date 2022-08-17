using System.Collections.Generic;
using System.Text;

namespace Mech3DotNet.Reader.Structs
{
    public struct SoundGroup
    {
        public string name;
        public int? play_count;
        public bool play_solo;
        public float? dynamic_weights;
        public float? weight;
        public float? delay_play;
        public float? min_delay;
        public List<SoundGroup> sounds;

        private void Repr(StringBuilder sb, int level)
        {
            sb.Append(' ', level * 2);
            sb.AppendFormat("SoundGroup<name='{0}'", name);
            if (play_count != null)
                sb.AppendFormat(", play_count={0}", play_count);
            if (play_solo)
                sb.Append(", play_solo");
            if (dynamic_weights != null)
                sb.AppendFormat(", dynamic_weights={0}", dynamic_weights);
            if (weight != null)
                sb.AppendFormat(", weight={0}", weight);
            if (delay_play != null)
                sb.AppendFormat(", delay_play={0}", delay_play);
            if (min_delay != null)
                sb.AppendFormat(", min_delay={0}", min_delay);
            if (sounds.Count > 0)
            {
                sb.Append(", sounds=[\n");
                foreach (var sound in sounds)
                {
                    sound.Repr(sb, level + 1);
                    sb.Append('\n');
                }
                sb.Append(' ', level * 2);
                sb.Append(']');
            }
            sb.Append('>');
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Repr(sb, 0);
            return sb.ToString();
        }
    }

    public struct ToSoundGroup : IConvertOperation<SoundGroup>
    {
        public static SoundGroup Convert(ReaderValue value, IEnumerable<string> path)
        {
            var list = ConversionException.List(value, path);
            var childPath = new IndexPath(path);
            var soundGroup = new SoundGroup()
            {
                sounds = new List<SoundGroup>(),
            };
            // every sound group has the name first
            soundGroup.name = ToStr.Convert(list[0], childPath.Path);
            childPath.Next();
            // then, the sound group has zero or more properties
            int i = 1;
            for (; i < list.Count; i++)
            {
                var item = list[i];
                // if we see a list, the properties have ended
                if (item is ReaderList)
                    break;

                var key = ToStr.Convert(item, childPath.Path);
                childPath.Next();
                switch (key)
                {
                    case "DYNAMIC_WEIGHTS":
                        i++;
                        soundGroup.dynamic_weights = ToFloat.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    case "WEIGHT":
                        i++;
                        soundGroup.weight = ToFloat.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    case "PLAY_COUNT":
                        i++;
                        soundGroup.play_count = ToInt.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    case "DELAY_PLAY":
                        i++;
                        soundGroup.delay_play = ToFloat.Convert(list[i], childPath.Path);
                        childPath.Next();
                        break;
                    case "PLAY_SOLO":
                        soundGroup.play_solo = true;
                        break;
                    case "EXTRA":
                        i++;
                        var extra = ToSoundGroupExtra.Convert(list[i], childPath.Path);
                        soundGroup.min_delay = extra.min_delay;
                        childPath.Next();
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{key}'", childPath.Path, list);
                }
            }
            // finally, the sound group contains other groups?
            for (; i < list.Count; i++)
            {
                var item = list[i];
                var child = ToSoundGroup.Convert(item, childPath.Path);
                childPath.Next();
                soundGroup.sounds.Add(child);
            }
            return soundGroup;
        }

        public SoundGroup ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static SoundGroup operator /(Query query, ToSoundGroup op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
