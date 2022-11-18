namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.FrameBufferEffectColorConverter))]
    public class FrameBufferEffectColor
    {
        public Rgba from;
        public Rgba to;
        public float runtime;
        public bool fudgeAlpha = false;

        public FrameBufferEffectColor(Rgba from, Rgba to, float runtime, bool fudgeAlpha)
        {
            this.from = from;
            this.to = to;
            this.runtime = runtime;
            this.fudgeAlpha = fudgeAlpha;
        }
    }
}
