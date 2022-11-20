namespace Mech3DotNet.Json.Nodes.Mw
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Mw.Converters.LightConverter))]
    public class Light
    {
        public string name;
        public Mech3DotNet.Json.Types.Vec3 direction;
        public float diffuse;
        public float ambient;
        public Mech3DotNet.Json.Types.Color color;
        public Mech3DotNet.Json.Types.Range range;
        public uint parentPtr;
        public uint dataPtr;

        public Light(string name, Mech3DotNet.Json.Types.Vec3 direction, float diffuse, float ambient, Mech3DotNet.Json.Types.Color color, Mech3DotNet.Json.Types.Range range, uint parentPtr, uint dataPtr)
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
