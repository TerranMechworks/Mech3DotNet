namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.EventStartConverter))]
    public struct EventStart
    {
        public StartOffset offset;
        public float time;

        public EventStart(StartOffset offset, float time)
        {
            this.offset = offset;
            this.time = time;
        }
    }
}
