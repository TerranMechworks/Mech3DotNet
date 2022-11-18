namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallAnimationTargetNodeConverter))]
    public class CallAnimationTargetNode
    {
        public string operandNode;

        public CallAnimationTargetNode(string operandNode)
        {
            this.operandNode = operandNode;
        }
    }
}
