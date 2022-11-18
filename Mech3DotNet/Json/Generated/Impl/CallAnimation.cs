namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.CallAnimationConverter))]
    public class CallAnimation
    {
        public string name;
        public ushort? waitForCompletion = null;
        public Mech3DotNet.Json.Anim.Events.CallAnimationParameters parameters;

        public CallAnimation(string name, ushort? waitForCompletion, Mech3DotNet.Json.Anim.Events.CallAnimationParameters parameters)
        {
            this.name = name;
            this.waitForCompletion = waitForCompletion;
            this.parameters = parameters;
        }
    }
}
