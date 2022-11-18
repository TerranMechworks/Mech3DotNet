namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.CallSequenceConverter))]
    public class CallSequence
    {
        public string name;

        public CallSequence(string name)
        {
            this.name = name;
        }
    }
}
