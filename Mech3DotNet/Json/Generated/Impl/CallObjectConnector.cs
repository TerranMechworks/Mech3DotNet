namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.CallObjectConnectorConverter))]
    public class CallObjectConnector
    {
        public string node;
        public string fromNode;
        public string toNode;
        public Mech3DotNet.Json.Types.Vec3 toPos;

        public CallObjectConnector(string node, string fromNode, string toNode, Mech3DotNet.Json.Types.Vec3 toPos)
        {
            this.node = node;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.toPos = toPos;
        }
    }
}
