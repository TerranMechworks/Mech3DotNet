namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectConnectorConverter))]
    public class ObjectConnector
    {
        public string node;
        public string? fromNode = null;
        public string? toNode = null;
        public Mech3DotNet.Json.Types.Vec3? fromPos = null;
        public Mech3DotNet.Json.Types.Vec3? toPos = null;
        public float? maxLength = null;

        public ObjectConnector(string node, string? fromNode, string? toNode, Mech3DotNet.Json.Types.Vec3? fromPos, Mech3DotNet.Json.Types.Vec3? toPos, float? maxLength)
        {
            this.node = node;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.fromPos = fromPos;
            this.toPos = toPos;
            this.maxLength = maxLength;
        }
    }
}
