namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectConnectorConverter))]
    public class ObjectConnector
    {
        public string node;
        public string? fromNode = null;
        public string? toNode = null;
        public Vec3? fromPos = null;
        public Vec3? toPos = null;
        public float? maxLength = null;

        public ObjectConnector(string node, string? fromNode, string? toNode, Vec3? fromPos, Vec3? toPos, float? maxLength)
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
