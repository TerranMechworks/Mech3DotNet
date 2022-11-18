namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectMotionTranslationConverter))]
    public class ObjectMotionTranslation
    {
        public Mech3DotNet.Json.Types.Vec3 delta;
        public Mech3DotNet.Json.Types.Vec3 initial;
        public Mech3DotNet.Json.Types.Vec3 unk;

        public ObjectMotionTranslation(Mech3DotNet.Json.Types.Vec3 delta, Mech3DotNet.Json.Types.Vec3 initial, Mech3DotNet.Json.Types.Vec3 unk)
        {
            this.delta = delta;
            this.initial = initial;
            this.unk = unk;
        }
    }
}
