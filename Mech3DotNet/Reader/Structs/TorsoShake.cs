using System.Collections.Generic;

namespace Mech3DotNet.Reader.Structs
{
    public struct TorsoShake
    {
        public float pitchAmp;
        public float yawAmp;
        public float rollAmp;
        public float freq;
        public float dampFreq;

        public override string ToString() => $"TorsoShake<pitch_amp={pitchAmp}, yaw_amp={yawAmp}, roll_amp={rollAmp}, freq={freq}, damp_freq={dampFreq}>";
    }

    public struct ToTorsoShake : IConvertOperation<TorsoShake>
    {
        public static TorsoShake Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var torsoShake = new TorsoShake();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "pitch_amp":
                        torsoShake.pitchAmp = ToFloat.Convert(item.value, item.path);
                        break;
                    case "yaw_amp":
                        torsoShake.yawAmp = ToFloat.Convert(item.value, item.path);
                        break;
                    case "roll_amp":
                        torsoShake.rollAmp = ToFloat.Convert(item.value, item.path);
                        break;
                    case "freq":
                        torsoShake.freq = ToFloat.Convert(item.value, item.path);
                        break;
                    case "damp_freq":
                        torsoShake.dampFreq = ToFloat.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return torsoShake;
        }

        public TorsoShake ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static TorsoShake operator /(Query query, ToTorsoShake op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
