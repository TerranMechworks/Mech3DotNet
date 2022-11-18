namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.LightConverter))]
    public class Light
    {
        public string name;
        public Vec3 direction;
        public float diffuse;
        public float ambient;
        public Color color;
        public Range range;
        public uint parentPtr;
        public uint dataPtr;

        public Light(string name, Vec3 direction, float diffuse, float ambient, Color color, Range range, uint parentPtr, uint dataPtr)
        {
            this.name = name;
            this.direction = direction;
            this.diffuse = diffuse;
            this.ambient = ambient;
            this.color = color;
            this.range = range;
            this.parentPtr = parentPtr;
            this.dataPtr = dataPtr;
        }
    }
}
