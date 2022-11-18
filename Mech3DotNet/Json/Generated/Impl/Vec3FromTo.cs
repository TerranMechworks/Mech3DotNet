namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.Vec3FromToConverter))]
    public class Vec3FromTo
    {
        public Vec3 from;
        public Vec3 to;
        public Vec3 delta;

        public Vec3FromTo(Vec3 from, Vec3 to, Vec3 delta)
        {
            this.from = from;
            this.to = to;
            this.delta = delta;
        }
    }
}
