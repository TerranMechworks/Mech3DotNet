namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectMotionSiFrameConverter))]
    public class ObjectMotionSiFrame
    {
        public float startTime;
        public float endTime;
        public TranslateData? translation = null;
        public RotateData? rotation = null;
        public ScaleData? scale = null;

        public ObjectMotionSiFrame(float startTime, float endTime, TranslateData? translation, RotateData? rotation, ScaleData? scale)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.translation = translation;
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}
