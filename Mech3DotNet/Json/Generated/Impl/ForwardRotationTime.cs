namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ForwardRotationTimeConverter))]
    public struct ForwardRotationTime
    {
        public float v1;
        public float v2;

        public ForwardRotationTime(float v1, float v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
