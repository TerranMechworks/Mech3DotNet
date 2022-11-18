namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.CallAnimationTargetNodeConverter))]
    public class CallAnimationTargetNode
    {
        public string operandNode;

        public CallAnimationTargetNode(string operandNode)
        {
            this.operandNode = operandNode;
        }
    }
}
