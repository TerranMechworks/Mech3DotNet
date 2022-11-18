namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.HwRenderCondConverter))]
    public struct HwRenderCond
    {
        public bool value;

        public HwRenderCond(bool value)
        {
            this.value = value;
        }
    }
}
