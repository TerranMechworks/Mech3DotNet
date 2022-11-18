namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.Vec3FromToConverter))]
    public class Vec3FromTo
    {
        public Mech3DotNet.Json.Types.Vec3 from;
        public Mech3DotNet.Json.Types.Vec3 to;
        public Mech3DotNet.Json.Types.Vec3 delta;

        public Vec3FromTo(Mech3DotNet.Json.Types.Vec3 from, Mech3DotNet.Json.Types.Vec3 to, Mech3DotNet.Json.Types.Vec3 delta)
        {
            this.from = from;
            this.to = to;
            this.delta = delta;
        }
    }
}
