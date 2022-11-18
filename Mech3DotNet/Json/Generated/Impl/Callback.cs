namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallbackConverter))]
    public class Callback
    {
        public uint value;

        public Callback(uint value)
        {
            this.value = value;
        }
    }
}
