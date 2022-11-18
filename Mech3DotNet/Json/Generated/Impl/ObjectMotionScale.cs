namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectMotionScaleConverter))]
    public class ObjectMotionScale
    {
        public Vec3 value;
        public Vec3 unk;

        public ObjectMotionScale(Vec3 value, Vec3 unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
