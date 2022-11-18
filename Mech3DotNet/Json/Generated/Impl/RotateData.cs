namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.RotateDataConverter))]
    public class RotateData
    {
        public Quaternion value;
        public byte[] unk;

        public RotateData(Quaternion value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
