namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.SeqDefConverter))]
    public class SeqDef
    {
        public string name;
        public SeqActivation activation;
        public System.Collections.Generic.List<Event> events;
        public uint pointer;

        public SeqDef(string name, SeqActivation activation, System.Collections.Generic.List<Event> events, uint pointer)
        {
            this.name = name;
            this.activation = activation;
            this.events = events;
            this.pointer = pointer;
        }
    }
}
