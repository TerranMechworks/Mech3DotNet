namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.RandomWeightCondConverter))]
    public struct RandomWeightCond
    {
        public float value;

        public RandomWeightCond(float value)
        {
            this.value = value;
        }
    }
}
