namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectActiveStateConverter))]
    public class ObjectActiveState
    {
        public string node;
        public bool state;

        public ObjectActiveState(string node, bool state)
        {
            this.node = node;
            this.state = state;
        }
    }
}
