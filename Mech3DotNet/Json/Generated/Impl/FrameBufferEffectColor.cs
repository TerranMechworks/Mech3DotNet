namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.FrameBufferEffectColorConverter))]
    public class FrameBufferEffectColor
    {
        public Mech3DotNet.Json.Anim.Events.Rgba from;
        public Mech3DotNet.Json.Anim.Events.Rgba to;
        public float runtime;
        public bool fudgeAlpha = false;

        public FrameBufferEffectColor(Mech3DotNet.Json.Anim.Events.Rgba from, Mech3DotNet.Json.Anim.Events.Rgba to, float runtime, bool fudgeAlpha)
        {
            this.from = from;
            this.to = to;
            this.runtime = runtime;
            this.fudgeAlpha = fudgeAlpha;
        }
    }
}
