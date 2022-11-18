namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.CallAnimationWithNodeConverter))]
    public class CallAnimationWithNode
    {
        public string node;
        public Mech3DotNet.Json.Types.Vec3? translation;

        public CallAnimationWithNode(string node, Mech3DotNet.Json.Types.Vec3? translation)
        {
            this.node = node;
            this.translation = translation;
        }
    }
}
