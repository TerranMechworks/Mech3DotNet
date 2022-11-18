namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectMotionTranslationConverter))]
    public class ObjectMotionTranslation
    {
        public Vec3 delta;
        public Vec3 initial;
        public Vec3 unk;

        public ObjectMotionTranslation(Vec3 delta, Vec3 initial, Vec3 unk)
        {
            this.delta = delta;
            this.initial = initial;
            this.unk = unk;
        }
    }
}
