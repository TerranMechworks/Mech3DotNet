namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.HwRenderCondConverter))]
    public struct HwRenderCond
    {
        public bool value;

        public HwRenderCond(bool value)
        {
            this.value = value;
        }
    }
}
