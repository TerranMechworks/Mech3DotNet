namespace Mech3DotNet.Json.Types
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Types.Converters.Vec3Converter))]
    public struct Vec3
    {
        public float x;
        public float y;
        public float z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
