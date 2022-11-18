namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectCycleTextureConverter))]
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
