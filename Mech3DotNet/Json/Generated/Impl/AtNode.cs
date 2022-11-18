namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.AtNodeConverter))]
    public class AtNode
    {
        public string node;
        public Vec3 translation;

        public AtNode(string node, Vec3 translation)
        {
            this.node = node;
            this.translation = translation;
        }
    }
}
