namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.SeqDefConverter))]
    public class SeqDef
    {
        public string name;
        public Mech3DotNet.Json.Anim.SeqActivation activation;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.Event> events;
        public uint pointer;

        public SeqDef(string name, Mech3DotNet.Json.Anim.SeqActivation activation, System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.Event> events, uint pointer)
        {
            this.name = name;
            this.activation = activation;
            this.events = events;
            this.pointer = pointer;
        }
    }
}
