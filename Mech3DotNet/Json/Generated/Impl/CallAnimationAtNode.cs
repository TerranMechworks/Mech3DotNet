namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallAnimationAtNodeConverter))]
    public class CallAnimationAtNode
    {
        public string node;
        public Vec3? translation;
        public Vec3? rotation;

        public CallAnimationAtNode(string node, Vec3? translation, Vec3? rotation)
        {
            this.node = node;
            this.translation = translation;
            this.rotation = rotation;
        }
    }
}
