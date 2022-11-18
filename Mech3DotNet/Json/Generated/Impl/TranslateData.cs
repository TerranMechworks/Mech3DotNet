namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TranslateDataConverter))]
    public class TranslateData
    {
        public Vec3 value;
        public byte[] unk;

        public TranslateData(Vec3 value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
