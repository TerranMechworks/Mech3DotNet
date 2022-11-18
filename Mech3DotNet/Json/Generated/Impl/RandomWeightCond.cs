namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.RandomWeightCondConverter))]
    public struct RandomWeightCond
    {
        public float value;

        public RandomWeightCond(float value)
        {
            this.value = value;
        }
    }
}
