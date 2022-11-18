namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectCycleTextureConverter))]
    public class ObjectCycleTexture
    {
        public string node;
        public ushort reset;

        public ObjectCycleTexture(string node, ushort reset)
        {
            this.node = node;
            this.reset = reset;
        }
    }
}
