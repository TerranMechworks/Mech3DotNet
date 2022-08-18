using System.Collections.Generic;
using System.Text;

namespace Mech3DotNet.Reader.Structs
{
    public struct SoundGroup
    {
        public string name;
        public int? playCount;
        public bool playSolo;
        public float? dynamicWeights;
        public float? weight;
        public float? delayPlay;
        public float? minDelay;
        public List<SoundGroup> sounds;

        private void Repr(StringBuilder sb, int level)
        {
            sb.Append(' ', level * 2);
            sb.AppendFormat("SoundGroup<name='{0}'", name);
            if (playCount != null)
                sb.AppendFormat(", play_count={0}", playCount);
            if (playSolo)
                sb.Append(", play_solo");
            if (dynamicWeights != null)
                sb.AppendFormat(", dynamic_weights={0}", dynamicWeights);
            if (weight != null)
                sb.AppendFormat(", weight={0}", weight);
            if (delayPlay != null)
                sb.AppendFormat(", delay_play={0}", delayPlay);
            if (minDelay != null)
                sb.AppendFormat(", min_delay={0}", minDelay);
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
            var index = new IndexWise(value, path);
            var soundGroup = new SoundGroup()
            {
                sounds = new List<SoundGroup>(),
            };
            // every sound group has the name first
            soundGroup.name = ToStr.Convert(index.Current, index.Path);
            index.Next();
            // then, the sound group has zero or more properties
            while (index.HasItems)
            {
                // if we see a list, the properties have ended
                if (index.Current is ReaderList)
                    break;

                var key = ToStr.Convert(index.Current, index.Path);
                // do not advance index yet, since we might need index.Path to
                // throw an error
                switch (key)
                {
                    case "DYNAMIC_WEIGHTS":
                        index.Next();
                        soundGroup.dynamicWeights = ToFloat.Convert(index.Current, index.Path);
                        break;
                    case "WEIGHT":
                        index.Next();
                        soundGroup.weight = ToFloat.Convert(index.Current, index.Path);
                        break;
                    case "PLAY_COUNT":
                        index.Next();
                        soundGroup.playCount = ToInt.Convert(index.Current, index.Path);
                        break;
                    case "DELAY_PLAY":
                        index.Next();
                        soundGroup.delayPlay = ToFloat.Convert(index.Current, index.Path);
                        break;
                    case "PLAY_SOLO":
                        soundGroup.playSolo = true;
                        break;
                    case "EXTRA":
                        index.Next();
                        var extra = ToSoundGroupExtra.Convert(index.Current, index.Path);
                        soundGroup.minDelay = extra.minDelay;
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{key}'", index.Path, index.Underlying);
                }
                index.Next();
            }
            // finally, the sound group contains other groups?
            while (index.HasItems)
            {
                var child = ToSoundGroup.Convert(index.Current, index.Path);
                index.Next();
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
            return op.ConvertTo(query._value, query._path);
        }
    }
}
