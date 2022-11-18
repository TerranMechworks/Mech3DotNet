namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectScaleStateConverter))]
    public class ObjectScaleState
    {
        public string node;
        public Vec3 scale;

        public ObjectScaleState(string node, Vec3 scale)
        {
            this.node = node;
            this.scale = scale;
        }
    }
}
