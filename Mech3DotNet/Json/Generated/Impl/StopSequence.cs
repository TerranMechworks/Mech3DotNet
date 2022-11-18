namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.StopSequenceConverter))]
    public class StopSequence
    {
        public string name;

        public StopSequence(string name)
        {
            this.name = name;
        }
    }
}
