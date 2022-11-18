namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.BoundingBoxConverter))]
    public class BoundingBox
    {
        public Vec3 a;
        public Vec3 b;

        public BoundingBox(Vec3 a, Vec3 b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
