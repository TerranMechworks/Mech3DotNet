namespace Mech3DotNet.Json.Gamez.Nodes
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Nodes.Converters.BoundingBoxConverter))]
    public class BoundingBox
    {
        public Mech3DotNet.Json.Types.Vec3 a;
        public Mech3DotNet.Json.Types.Vec3 b;

        public BoundingBox(Mech3DotNet.Json.Types.Vec3 a, Mech3DotNet.Json.Types.Vec3 b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
