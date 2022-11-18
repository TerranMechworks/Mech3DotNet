namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallObjectConnectorConverter))]
    public class CallObjectConnector
    {
        public string node;
        public string fromNode;
        public string toNode;
        public Vec3 toPos;

        public CallObjectConnector(string node, string fromNode, string toNode, Vec3 toPos)
        {
            this.node = node;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.toPos = toPos;
        }
    }
}
