namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallSequenceConverter))]
    public class CallSequence
    {
        public string name;

        public CallSequence(string name)
        {
            this.name = name;
        }
    }
}
