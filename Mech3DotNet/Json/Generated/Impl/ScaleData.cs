namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ScaleDataConverter))]
    public class ScaleData
    {
        public Vec3 value;
        public byte[] unk;

        public ScaleData(Vec3 value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
