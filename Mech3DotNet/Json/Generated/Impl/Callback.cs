namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.CallbackConverter))]
    public class Callback
    {
        public uint value;

        public Callback(uint value)
        {
            this.value = value;
        }
    }
}
