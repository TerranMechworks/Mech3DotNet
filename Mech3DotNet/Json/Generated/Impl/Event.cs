namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.EventConverter))]
    public class Event
    {
        public Mech3DotNet.Json.Anim.Events.EventData data;
        public Mech3DotNet.Json.Anim.Events.EventStart? start;

        public Event(Mech3DotNet.Json.Anim.Events.EventData data, Mech3DotNet.Json.Anim.Events.EventStart? start)
        {
            this.data = data;
            this.start = start;
        }
    }
}
