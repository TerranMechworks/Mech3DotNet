namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectOpacityConverter))]
    public struct ObjectOpacity
    {
        public float value;
        public short state;

        public ObjectOpacity(float value, short state)
        {
            this.value = value;
            this.state = state;
        }
    }
}
