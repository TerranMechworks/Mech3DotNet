namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.CallAnimationAtNodeConverter))]
    public class CallAnimationAtNode
    {
        public string node;
        public Mech3DotNet.Json.Types.Vec3? translation;
        public Mech3DotNet.Json.Types.Vec3? rotation;

        public CallAnimationAtNode(string node, Mech3DotNet.Json.Types.Vec3? translation, Mech3DotNet.Json.Types.Vec3? rotation)
        {
            this.node = node;
            this.translation = translation;
            this.rotation = rotation;
        }
    }
}
