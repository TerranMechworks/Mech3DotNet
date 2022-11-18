namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectMotionSiFrameConverter))]
    public class ObjectMotionSiFrame
    {
        public float startTime;
        public float endTime;
        public Mech3DotNet.Json.Anim.Events.TranslateData? translation = null;
        public Mech3DotNet.Json.Anim.Events.RotateData? rotation = null;
        public Mech3DotNet.Json.Anim.Events.ScaleData? scale = null;

        public ObjectMotionSiFrame(float startTime, float endTime, Mech3DotNet.Json.Anim.Events.TranslateData? translation, Mech3DotNet.Json.Anim.Events.RotateData? rotation, Mech3DotNet.Json.Anim.Events.ScaleData? scale)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.translation = translation;
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}
