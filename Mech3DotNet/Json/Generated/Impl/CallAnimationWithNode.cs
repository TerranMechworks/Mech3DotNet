namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallAnimationWithNodeConverter))]
    public class CallAnimationWithNode
    {
        public string node;
        public Vec3? translation;

        public CallAnimationWithNode(string node, Vec3? translation)
        {
            this.node = node;
            this.translation = translation;
        }
    }
}
