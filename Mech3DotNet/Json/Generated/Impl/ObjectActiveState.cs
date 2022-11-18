namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectActiveStateConverter))]
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
