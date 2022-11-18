namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallAnimationConverter))]
    public class CallAnimation
    {
        public string name;
        public ushort? waitForCompletion = null;
        public CallAnimationParameters parameters;

        public CallAnimation(string name, ushort? waitForCompletion, CallAnimationParameters parameters)
        {
            this.name = name;
            this.waitForCompletion = waitForCompletion;
            this.parameters = parameters;
        }
    }
}
