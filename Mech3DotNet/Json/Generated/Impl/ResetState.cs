namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.ResetStateConverter))]
    public class ResetState
    {
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.Event> events;
        public uint pointer;

        public ResetState(System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.Event> events, uint pointer)
        {
            this.events = events;
            this.pointer = pointer;
        }
    }
}
