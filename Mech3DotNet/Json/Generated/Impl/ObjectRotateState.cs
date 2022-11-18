namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectRotateStateConverter))]
    public class ObjectRotateState
    {
        public string node;
        public Mech3DotNet.Json.Anim.Events.RotateState rotate;

        public ObjectRotateState(string node, Mech3DotNet.Json.Anim.Events.RotateState rotate)
        {
            this.node = node;
            this.rotate = rotate;
        }
    }
}
