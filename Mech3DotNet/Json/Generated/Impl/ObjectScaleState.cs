namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectScaleStateConverter))]
    public class ObjectScaleState
    {
        public string node;
        public Mech3DotNet.Json.Types.Vec3 scale;

        public ObjectScaleState(string node, Mech3DotNet.Json.Types.Vec3 scale)
        {
            this.node = node;
            this.scale = scale;
        }
    }
}
