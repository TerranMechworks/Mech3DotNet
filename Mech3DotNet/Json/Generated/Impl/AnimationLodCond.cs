namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.AnimationLodCondConverter))]
    public struct AnimationLodCond
    {
        public uint value;

        public AnimationLodCond(uint value)
        {
            this.value = value;
        }
    }
}
