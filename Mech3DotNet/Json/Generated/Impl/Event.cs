namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.EventConverter))]
    public class Event
    {
        public EventData data;
        public EventStart? start;

        public Event(EventData data, EventStart? start)
        {
            this.data = data;
            this.start = start;
        }
    }
}
