namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.EventStartConverter))]
    public struct EventStart
    {
        public Mech3DotNet.Json.Anim.Events.StartOffset offset;
        public float time;

        public EventStart(Mech3DotNet.Json.Anim.Events.StartOffset offset, float time)
        {
            this.offset = offset;
            this.time = time;
        }
    }
}
