namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectOpacityStateConverter))]
    public class ObjectOpacityState
    {
        public string node;
        public bool isSet;
        public bool state;
        public float opacity;

        public ObjectOpacityState(string node, bool isSet, bool state, float opacity)
        {
            this.node = node;
            this.isSet = isSet;
            this.state = state;
            this.opacity = opacity;
        }
    }
}
