namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectTranslateStateConverter))]
    public class ObjectTranslateState
    {
        public string node;
        public Mech3DotNet.Json.Types.Vec3 translate;
        public string? atNode = null;

        public ObjectTranslateState(string node, Mech3DotNet.Json.Types.Vec3 translate, string? atNode)
        {
            this.node = node;
            this.translate = translate;
            this.atNode = atNode;
        }
    }
}
