namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ForwardRotationDistanceConverter))]
    public struct ForwardRotationDistance
    {
        public float v1;

        public ForwardRotationDistance(float v1)
        {
            this.v1 = v1;
        }
    }
}
