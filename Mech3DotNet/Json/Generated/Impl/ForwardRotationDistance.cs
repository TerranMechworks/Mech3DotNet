namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ForwardRotationDistanceConverter))]
    public struct ForwardRotationDistance
    {
        public float v1;

        public ForwardRotationDistance(float v1)
        {
            this.v1 = v1;
        }
    }
}
