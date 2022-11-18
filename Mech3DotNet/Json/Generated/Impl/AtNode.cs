namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.AtNodeConverter))]
    public class AtNode
    {
        public string node;
        public Mech3DotNet.Json.Types.Vec3 translation;

        public AtNode(string node, Mech3DotNet.Json.Types.Vec3 translation)
        {
            this.node = node;
            this.translation = translation;
        }
    }
}
