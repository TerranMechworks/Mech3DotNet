namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectMotionScaleConverter))]
    public class ObjectMotionScale
    {
        public Mech3DotNet.Json.Types.Vec3 value;
        public Mech3DotNet.Json.Types.Vec3 unk;

        public ObjectMotionScale(Mech3DotNet.Json.Types.Vec3 value, Mech3DotNet.Json.Types.Vec3 unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
