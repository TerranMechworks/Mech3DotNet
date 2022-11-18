namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ResetStateConverter))]
    public class ResetState
    {
        public System.Collections.Generic.List<Event> events;
        public uint pointer;

        public ResetState(System.Collections.Generic.List<Event> events, uint pointer)
        {
            this.events = events;
            this.pointer = pointer;
        }
    }
}
