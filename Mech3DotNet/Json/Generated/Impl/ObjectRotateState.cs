namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectRotateStateConverter))]
    public class ObjectRotateState
    {
        public string node;
        public RotateState rotate;

        public ObjectRotateState(string node, RotateState rotate)
        {
            this.node = node;
            this.rotate = rotate;
        }
    }
}
