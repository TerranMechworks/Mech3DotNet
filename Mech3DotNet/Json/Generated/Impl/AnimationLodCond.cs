namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.AnimationLodCondConverter))]
    public struct AnimationLodCond
    {
        public uint value;

        public AnimationLodCond(uint value)
        {
            this.value = value;
        }
    }
}
